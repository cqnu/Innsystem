<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechnicalInformation_ProductList.aspx.cs" Inherits="_863soft.ISS.Web.TechnicalInformation.ProductList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <form id="form1" runat="server">
        <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
            <tr>
                <td style="width: 80px" align="right" class="tdbg">
                    <b>关键字：</b>
                </td>
                <td class="tdbg">
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click"></asp:Button>
                    <asp:Button ID="btnAdd" runat="server" Text="发布新产品" OnClick="btnAdd_Click" />
                </td>
                <td class="tdbg"></td>
            </tr>
        </table>

        <div style="width: 750px; height: 600px;">

            <div style="width: 750px; height: 550px; text-align: center">

                <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" CellSpacing="10">

                    <ItemTemplate>

                        <div style="width: 100%; height: 100%">
                            <table style="width: 350px; height: 180px; text-align: center"  bgcolor="#FFFFFF"
                                onmouseover="this.style.borderColor='#00FF00';this.style.backgroundColor='#F8F8FF';"  
onmouseout="this.style.borderColor='#FF0000';this.style.backgroundColor='#FFFFFF';">
                                <tr>
                                    <td style="text-align: left; width: 100px">
                                        <asp:ImageButton ID="Image1" runat="server" Height="100px" Width="100" ImageUrl='<%#Eval("picurl") %>'
                                            PostBackUrl='<%#Eval("url") %>' />
                                    </td>
                                    <td style="text-align: left">
                                        <table>
                                            <tr>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("EntryName") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align:left">
                                        关键字:
                                        <asp:Label ID="Label3" runat="server" Text= '<%#Eval("Keyword") %>'></asp:Label>
                                    </td>
                                   
                                </tr>
                            </table>




                        </div>

                    </ItemTemplate>

                </asp:DataList>

            </div>

            <div style="width: 750px; height: 50px">

             <asp:LinkButton ID="linkbtnone" runat="server" OnClick="linkbtnone_Click">首页</asp:LinkButton>

            <asp:LinkButton ID="linkbtnpre" runat="server" OnClick="linkbtnpre_Click">上一页</asp:LinkButton>

            <asp:LinkButton ID="linkbtnnext" runat="server" OnClick="linkbtnnext_Click">下一页</asp:LinkButton>

            <asp:LinkButton ID="linkbtnlast" runat="server" OnClick="linkbtnlast_Click">尾页</asp:LinkButton>

            <asp:Label ID="labcp" runat="server"></asp:Label>[<asp:Label ID="labpage" runat="server" Text="1"></asp:Label>/<asp:Label ID="labtp" runat="server"></asp:Label>]

            <asp:Label ID="labgoto" runat="server" Text="转到："></asp:Label>

            <asp:TextBox ID="txtgo" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" runat="server" Height="15px" Width="30px"></asp:TextBox>页

            <asp:Button ID="BtnGo" runat="server" Text="GO" Width="36px" OnClick="BtnGo_Click" />   

            </div>

        </div>
    </form>
</body>

</html>
