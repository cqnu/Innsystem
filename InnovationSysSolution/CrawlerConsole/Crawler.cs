using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrawlerConsole
{
    class Crawler
    {
        private static readonly object obj = new object();

        public static List<CrawlerHelper> oldPages = new List<CrawlerHelper>();//这是爬取的历史，从数据库中读取
        public static List<CrawlerHelper> newPages = new List<CrawlerHelper>();//最终采集到的url列表
        public static List<CrawlerHelper> existPages = new List<CrawlerHelper>();//本次爬取之后包含负面信息的列表

        /// <summary>
        /// 爬虫爬行队列
        /// </summary>
        public static List<string> urls = new List<string>();   //请求的网址集合
        public static List<string> tempUrlName = new List<string>();    //网站的名称
        public static List<string> urlKeys = new List<string>();    //网站网址消息主目录（消息的根目录）
        public static List<string> keywords = new List<string>();   //关键词
        public static int length = 0;
        public static Thread[] workThreads;

        public static void Run()
        {
            GetCrawler();
            isAlive();
        }

        public static void GetCrawler()
        {
            newPages = new List<CrawlerHelper>();
            existPages = new List<CrawlerHelper>();
            oldPages = new List<CrawlerHelper>();
            CrawlerHelper ch = new CrawlerHelper();
            DataTable dtUrl = ch.GetData(1);
            DataTable dtKey = ch.GetData(0);
            urls.Clear();
            keywords.Clear();

            if (dtUrl == null)
                Run();
            //Url、网站名称、网站网址消息主目录（消息的根目录）
            for (int i = 0; i < dtUrl.Rows.Count; i++)
            {
                urls.Add(dtUrl.Rows[i]["Keys"].ToString());
                tempUrlName.Add(dtUrl.Rows[i]["KeyName"].ToString());
                urlKeys.Add(dtUrl.Rows[i]["URLKey"].ToString());
            }
            //关键字
            for (int i = 0; i < dtKey.Rows.Count; i++)
            {
                keywords.Add(dtKey.Rows[i]["Keys"].ToString());
            }

            //线程
            workThreads = new Thread[urls.Count];
            CrawlerExe ce;
            length = 0;
            //循环创建并启动线程执行  
            for (int i = 0; i < workThreads.Length; i++)
            {
                ce = new CrawlerExe();
                if (workThreads[i] == null)
                {
                    ce = new CrawlerExe();
                    ce.threadUrl = new List<string>();
                    ce.threadUrl.Add(urls[i].ToString());
                    ce.length = length;

                    //如果线程不存在，则创建  
                    workThreads[i] = new Thread(new ThreadStart(ce.Crawlers));
                    workThreads[i].Name = i.ToString();
                    workThreads[i].Start();
                }
                else
                {
                    //已经存在，如果没有运行，则启动  
                    if (workThreads[i].ThreadState == ThreadState.Aborted || workThreads[i].ThreadState == ThreadState.Stopped)
                    {
                        ce = new CrawlerExe();
                        ce.threadUrl = new List<string>();
                        ce.threadUrl.Add(urls[i].ToString());
                        ce.length = length;

                        workThreads[i] = new Thread(new ThreadStart(ce.Crawlers));
                        workThreads[i].Name = i.ToString();
                        workThreads[i].Start();
                    }
                    else
                    {
                        workThreads[i].Start();
                    }
                }
            }
        }

        public class CrawlerExe
        {
            public List<string> threadUrl;
            public int length;
            public List<string> urlName;
            public void Crawlers()
            {
                CrawlerContent(threadUrl, newPages, length, urlKeys);//爬虫
                CrawlerInfo();//填充数据库
            }
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        public static void CrawlerInfo()
        {
            for (int i = 0; i < newPages.Count; i++)
            {
                CrawlerHelper model = newPages[i];
                if (model.Url.Trim('\\').EndsWith(".cn") || model.Url.Trim('\\').EndsWith(".com") || string.IsNullOrEmpty(model.Title.Trim(' ')))
                {
                    continue;
                }

                if (!(model.Url.Trim('\\').EndsWith(".html") || model.Url.Trim('\\').EndsWith(".htm") || model.Url.Trim('\\').EndsWith(".shtml")))
                {
                    continue;
                }

                foreach (var item in keywords)
                {
                    if (model.Content.Contains(item))
                    {
                        existPages.Add(model);
                    }
                }
            }

            try
            {
                lock (obj)
                {
                    oldPages.AddRange(newPages);
                }
            }
            catch (Exception)
            {
            }
            
            //填充数据
            CrawlerHelper pageDal = new CrawlerHelper();
            pageDal.Add(existPages);

        }

        /// <summary>
        /// 判断线程是否全部执行完成
        /// </summary>
        public static void isAlive()
        {
            ////判断多线程是否结束
            bool IfTimesEnd = false;

            //判断线程的IsAlive属性
            //IsAlive标识此线程已启动并且尚未正常终止或中止，则为 true；否则为 false。
            int aliveCount = 0;
            while (aliveCount != urls.Count)
            {
                for (int i = 0; i < workThreads.Length; i++)
                {
                    if (!workThreads[i].IsAlive)
                    {
                        aliveCount++;
                    }
                }
            }
            if (aliveCount == workThreads.Length)
            {
                IfTimesEnd = true;
            }
            //线程全部执行完成则重新爬虫
            if (IfTimesEnd)
            {
                Console.WriteLine("再次爬取");

                GetCrawler();
                isAlive();
            }
        }

        /// <summary>
        /// 爬虫主程序
        /// </summary>
        /// <param name="pages">搜集的网页信息</param>
        public static void CrawlerContent(List<string> colUrls, List<CrawlerHelper> pages, int length, List<string> urlKeys)
        {
            for (int i = 0; i < colUrls.Count; i++)
            {
                try
                {
                    string currentUrl = colUrls[i];

                    if (currentUrl.EndsWith("/"))
                    {
                        currentUrl = currentUrl.Substring(0, currentUrl.Length - 1);
                    }
                    if (currentUrl.EndsWith(".jpg") || currentUrl.EndsWith(".png") || currentUrl.EndsWith(".js") || currentUrl.EndsWith(".css") || currentUrl.EndsWith(".gif"))
                    {
                        continue;
                    }
                    string title = string.Empty;
                    string content = string.Empty;
                    List<string> childrenLink = null;
                    List<string> childrens = new List<string>();

                    if (pages.Where(n => n.Url == currentUrl.ToLower()).Count() == 0)
                    {
                        //todo?
                        Console.WriteLine(currentUrl);
                        //爬二级
                        HtmlHelper html = HtmlHelper.CreatHtml(new Uri(currentUrl));
                        if (html != null)
                        {
                            childrenLink = html.ChildrenLink.Select(o => o.ToString()).ToList();

                            foreach (var item in childrenLink)
                            {
                                foreach (var tempItem in urlKeys)
                                {
                                    if (item.Contains(tempItem))
                                    {
                                        childrens.Add(item);
                                    }
                                }
                            }

                            CrawlerThree(childrens, pages, length, urlKeys);
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
        }


        /// <summary>
        /// 爬虫程序  三级
        /// </summary>
        /// <param name="pages">搜集的网页信息</param>
        public static void CrawlerThree(List<string> colUrls, List<CrawlerHelper> pages, int length, List<string> urlKeys)
        {
            for (int i = 0; i < colUrls.Count; i++)
            {
                try
                {
                    string currentUrl = colUrls[i];
                    if (currentUrl.EndsWith("/"))
                    {
                        currentUrl = currentUrl.Substring(0, currentUrl.Length - 1);
                    }
                    if (currentUrl.EndsWith(".jpg") || currentUrl.EndsWith(".png") || currentUrl.EndsWith(".js") || currentUrl.EndsWith(".css") || currentUrl.EndsWith(".gif"))
                    {
                        continue;
                    }
                    string title = string.Empty;
                    string content = string.Empty;

                    if (pages.Where(n => n.Url == currentUrl.ToLower()).Count() == 0)
                    {
                        //todo?
                        Console.WriteLine(currentUrl);
                        //爬三级

                        HtmlHelper html = HtmlHelper.CreatHtml(new Uri(currentUrl));
                        if (html != null)
                        {
                            bool getContent = false;
                            CrawlerConsole.Html2Article.ArticleDocument ad = Html2Article.GetArticle(html, currentUrl, ref getContent);

                            if (getContent)
                            {
                                CrawlerHelper page = new CrawlerHelper
                                {
                                    Url = currentUrl.ToLower(),
                                    Title = ad.Title,
                                    Date = DateTime.Now.ToShortDateString(),
                                    Content = ad.Content
                                };

                                pages.Add(page);
                            }
                            else
                            {
                                CrawlerHelper page = new CrawlerHelper
                                {
                                    Url = currentUrl.ToLower(),
                                    Title = html.Title,
                                    Date = DateTime.Now.ToShortDateString(),
                                    Content = html.Content,
                                };

                                pages.Add(page);
                            }
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
