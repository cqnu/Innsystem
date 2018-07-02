using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace HN863Soft.ISS.Common
{
    public class EnumsHelper
    {
        /// <summary>
        /// 统一管理操作枚举
        /// </summary>
        public enum ActionEnum
        {
            /// <summary>
            /// 所有
            /// </summary>
            All,
            /// <summary>
            /// 显示
            /// </summary>
            Show,
            /// <summary>
            /// 查看
            /// </summary>
            View,
            /// <summary>
            /// 添加
            /// </summary>
            Add,
            /// <summary>
            /// 修改
            /// </summary>
            Edit,
            /// <summary>
            /// 删除
            /// </summary>
            Delete,
            /// <summary>
            /// 审核
            /// </summary>
            Audit,
            /// <summary>
            /// 回复
            /// </summary>
            Reply,
            /// <summary>
            /// 确认
            /// </summary>
            Confirm,
            /// <summary>
            /// 取消
            /// </summary>
            Cancel,
            /// <summary>
            /// 作废
            /// </summary>
            Invalid,
            /// <summary>
            /// 生成
            /// </summary>
            Build,
            /// <summary>
            /// 安装
            /// </summary>
            Instal,
            /// <summary>
            /// 卸载
            /// </summary>
            UnLoad,
            /// <summary>
            /// 登录
            /// </summary>
            Login,
            /// <summary>
            /// 备份
            /// </summary>
            Back,
            /// <summary>
            /// 还原
            /// </summary>
            Restore,
            /// <summary>
            /// 替换
            /// </summary>
            Replace,
            /// <summary>
            /// 复制
            /// </summary>
            Copy,
            /// <summary>
            /// 减少
            /// </summary>
            Reduce
        }

        /// <summary>
        /// 系统导航菜单类别枚举
        /// </summary>
        public enum NavigationEnum
        {
            /// <summary>
            /// 系统后台菜单
            /// </summary>
            System,
            /// <summary>
            /// 会员中心导航
            /// </summary>
            Users,
            /// <summary>
            /// 网站主导航
            /// </summary>
            WebSite
        }

        /// <summary>
        /// 用户生成码枚举
        /// </summary>
        public enum CodeEnum
        {
            /// <summary>
            /// 注册验证
            /// </summary>
            RegVerify,
            /// <summary>
            /// 邀请注册
            /// </summary>
            Register,
            /// <summary>
            /// 取回密码
            /// </summary>
            Password
        }

        /// <summary>
        /// 是否可用
        /// </summary>
        public enum IsUseableEnum
        {
            /// <summary>
            /// 可用
            /// </summary>
            useable,
            /// <summary>
            /// 不可用
            /// </summary>
            unuseable
        }

        /// <summary>
        /// 机构类型
        /// </summary>
        public enum OrgnizationEnum
        {
            /// <summary>
            /// 专家
            /// </summary>
            expert = 0,
            /// <summary>
            /// 机构
            /// </summary>
            Organization = 1,
            /// <summary>
            /// 公司
            /// </summary>
            Company = 2,
            /// <summary>
            /// 其它
            /// </summary>
            other = 3
        }

        /// <summary>
        /// 工业类型
        /// </summary>
        public enum IndustrialType
        {
            ///// <summary>
            ///// 外观设计
            ///// </summary>
            [Description("外观设计")]
            Exterior = 0,

            /// <summary>
            /// 样品设计
            /// </summary>
            [Description("样品设计")]
            Sample = 1,

            /// <summary>
            /// 成套解决方案
            /// </summary>
            [Description("成套解决方案")]
            Solution = 2,

            /// <summary>
            /// 3D培训
            /// </summary>
            [Description("3D培训")]
            Train3D = 3
        }

        /// <summary>
        /// 人才服务类型
        /// </summary>
        public enum TalentServiceType
        {
            /// <summary>
            /// 招聘信息
            /// </summary>
            [Description("招聘信息")]
            RecruitInfo,

            /// <summary>
            /// 培训班信息
            /// </summary>
            [Description("培训班信息")]
            TrainClassInfo
        }

        /// <summary>
        /// 软件服务类型
        /// </summary>
        public enum SoftwareServiceType
        {
            /// <summary>
            /// 开发
            /// </summary>
            [Description("开发")]
            Development,
            /// <summary>
            /// 测试
            /// </summary>
            [Description("测试")]
            Testing,
            /// <summary>
            /// 培训
            /// </summary>
            [Description("培训")]
            Training

        }

        /// <summary>
        /// 双软认定咨询服务类型
        /// </summary>
        public enum SoftConsulting
        {
            /// <summary>
            /// 产品认证
            /// </summary>
            [Description("产品认证")]
            ProductCertification,

            /// <summary>
            /// 企业认证
            /// </summary>
            [Description("企业认证")]
            EnterpriseCertification

        }

        /// <summary>
        /// 专业技术服务
        /// </summary>
        public enum SoftType
        {
            /// <summary>
            /// 工业类型
            /// </summary>
            [Description("工业设计")]
            IndustrialType,

            /// <summary>
            /// 人才服务类型
            /// </summary>
            [Description("人才服务")]
            TalentServiceType,

            /// <summary>
            /// 软件服务类型
            /// </summary>
            [Description("软件服务")]
            SoftwareServiceType,

            /// <summary>
            /// 双软认定咨询服务类型
            /// </summary>
            [Description("双软认定咨询")]
            SoftConsulting,

            /// <summary>
            /// 高企认定咨询
            /// </summary>
            [Description("高企认定咨询")]
            HSEConsulting

        }

        /// <summary>
        /// 吐槽类型
        /// </summary>
        public enum ForumCategory
        {
            /// <summary>
            /// 技术难题
            /// </summary>
            [Description("技术难题")]
            TechniqueProblem,
            /// <summary>
            /// 团队管理
            /// </summary>
            [Description("团队管理")]
            TeamManager,
            /// <summary>
            /// 企业管理
            /// </summary>
            [Description("企业管理")]
            EnterpriseManager

        }

        /// <summary>
        /// 论坛等级名称
        /// </summary>
        public enum ForumLevel
        {
            /// <summary>
            /// 论坛新兵对应经验值：100
            /// </summary>
            [Description("100")]
            论坛新兵,
            /// <summary>
            /// 论坛卫士对应经验值：500
            /// </summary>
            [Description("500")]
            论坛卫士,
            /// <summary>
            /// 论坛特使对应经验值：1000
            /// </summary>
            [Description("1000")]
            论坛特使,
            /// <summary>
            /// 论坛精英对应经验值：5000
            /// </summary>
            [Description("5000")]
            论坛精英,
            /// <summary>
            /// 论坛长者对应经验值：15000
            /// </summary>
            [Description("15000")]
            论坛长者,
            /// <summary>
            /// 论坛贤者对应经验值：25000
            /// </summary>
            [Description("25000")]
            论坛贤者,
            /// <summary>
            /// 论坛长老对应经验值：40000
            /// </summary>
            [Description("40000")]
            论坛长老,
            /// <summary>
            /// 论坛尊者对应经验值：60000
            /// </summary>
            [Description("60000")]
            论坛尊者,
            /// <summary>
            /// 论坛至尊对应经验值：90000
            /// </summary>
            [Description("90000")]
            论坛至尊,
            /// <summary>
            /// 论坛圣贤对应经验值：150000
            /// </summary>
            [Description("150000")]
            论坛圣贤,
            /// <summary>
            /// 论坛王者对应经验值：250000
            /// </summary>
            [Description("250000")]
            论坛王者,
            /// <summary>
            /// 论坛传奇对应经验值：400000
            /// </summary>
            [Description("400000")]
            论坛传奇
        }

        /// <summary>
        /// 任务对应经验
        /// </summary>
        public enum UserUpLevel
        {
            /// <summary>
            /// 普通吐槽发表任务
            /// </summary>
            [Description("发表吐槽 +5经验值 每帖经验值上限为10经验值！")]
            CommentExp=5,
            /// <summary>
            /// 疑问发表任务
            /// </summary>
            [Description("发帖 +15经验值 每帖经验值上限为150经验值！")]
            QuestionRelease=15
        }

        public enum MechanismType
        {
            /// <summary>
            /// 孵化器
            /// </summary>
            [Description("孵化器")]
            Incubator,
            /// <summary>
            /// 创客空间
            /// </summary>
            [Description("创客空间")]
            CreatingGuestSpace
        }

        /// <summary>
        /// 爬虫关键字类型
        /// </summary>
        public enum CrawlerKeyType
        {
            /// <summary>
            /// 关键词
            /// </summary>
            [Description("关键词")]
            KeyWords,
            /// <summary>
            /// 网址
            /// </summary>
            [Description("网址")]
            Urls
        }

        #region 获取注释信息 方法重载

        /// <summary>
        /// 方法获取注释信息
        /// </summary>
        /// <param name="value">人才服务类型</param>
        /// <returns></returns>
        public static string FetchDescription(TalentServiceType value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])fi.GetCustomAttributes(
               typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// 方法重载
        /// </summary>
        /// <param name="value">工业类型</param>
        /// <returns></returns>
        public static string FetchDescription(IndustrialType value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])fi.GetCustomAttributes(
               typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// 方法重载
        /// </summary>
        /// <param name="value">软件服务类型</param>
        /// <returns></returns>
        public static string FetchDescription(SoftwareServiceType value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])fi.GetCustomAttributes(
               typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// 方法重载
        /// </summary>
        /// <param name="value">双软认定咨询服务类型</param>
        /// <returns></returns>
        public static string FetchDescription(SoftConsulting value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])fi.GetCustomAttributes(
               typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// 方法重载
        /// </summary>
        /// <param name="value">工业类型</param>
        /// <returns></returns>
        public static string FetchDescription(SoftType value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])fi.GetCustomAttributes(
               typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// 方法重载
        /// </summary>
        /// <param name="value">吐槽分类</param>
        /// <returns></returns>
        public static string FetchDescription(ForumCategory value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])fi.GetCustomAttributes(
               typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// 方法重载
        /// </summary>
        /// <param name="value">论坛等级名称</param>
        /// <returns></returns>
        public static string FetchDescription(ForumLevel value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])fi.GetCustomAttributes(
               typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// 方法重载
        /// </summary>
        /// <param name="value">论坛等级名称</param>
        /// <returns></returns>
        public static string FetchDescription(UserUpLevel value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])fi.GetCustomAttributes(
               typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// 方法重载
        /// </summary>
        /// <param name="value">机构类型</param>
        /// <returns></returns>
        public static string FetchDescription(MechanismType value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])fi.GetCustomAttributes(
               typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// 方法重载
        /// </summary>
        /// <param name="value">吐槽分类</param>
        /// <returns></returns>
        public static string FetchDescription(CrawlerKeyType value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])fi.GetCustomAttributes(
               typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        #endregion

    }
}
