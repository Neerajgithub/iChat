<%@ Page Title="Users" Language="C#" MasterPageFile="~/admin/admin_master.master" AutoEventWireup="true"
    CodeFile="users.aspx.cs" Inherits="admin_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="misc" class="keepCenter">
        <div id="errorDiv" class="showInfo">
        </div>
        <div id="succDiv" class="showInfo">
        </div>
        <div id="infoDiv" class="showInfo">
        </div>
        <div id="warnDiv" class="showInfo">
        </div>
    </div>
    <div class="content-box">
        <div class="content-box-header">
            <h3>
                Users</h3>
        </div>
        <div class="content-box-content">
            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" CssClass="GridClass"
                AllowPaging="True" OnPageIndexChanging="gvUsers_PageIndexChanging" PageSize="30"
                OnRowDeleting="gvUsers_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="user_id" HeaderText="USER ID">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="email" HeaderText="EMAIL">
                        <ItemStyle Width="220px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fname" HeaderText="FISRT NAME">
                        <ItemStyle Width="150px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="lname" HeaderText="LAST NAME">
                        <ItemStyle Width="150px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="REPORT ABUSES">
                        <ItemTemplate>
                            <span class='<%# (Convert.ToInt64(DataBinder.Eval(Container.DataItem, "abuses"))>2) ? "abuse_box_red" : "abuse_box_green" %>'><%# DataBinder.Eval(Container.DataItem, "abuses")%></span>
                        </ItemTemplate>
                        <ItemStyle Width="38px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PUBLIC MESSAGE">
                        <ItemTemplate>
                            <a href='<%# "m_public.aspx?user=" + DataBinder.Eval(Container.DataItem, "user_id").ToString()%>'
                                class="aGVLinkEdit" title="View Public Messages">View</a>
                        </ItemTemplate>
                        <ItemStyle Width="38px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRIVATE MESSAGE">
                        <ItemTemplate>
                            <a href='<%# "m_private.aspx?user=" + DataBinder.Eval(Container.DataItem, "user_id").ToString()%>'
                                class="aGVLinkEdit" title="View Private Messages">View</a>
                        </ItemTemplate>
                        <ItemStyle Width="38px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="gvEmpDeleteLink" runat="server" CausesValidation="False" CssClass="aGVLinkDelete"
                                OnClientClick="return conf();" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="38px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="GridHead" />
                <RowStyle CssClass="GridRow" />
                <SelectedRowStyle CssClass="GridRowSelected" />
                <EmptyDataTemplate>
                    <table class="GridClass" cellspacing="0" rules="all" border="0" style="border-collapse: collapse;">
                        <tr class="GridHead">
                            <th style="width: 100px;">
                                USER ID
                            </th>
                            <th style="width: 220px;">
                                EMAIL
                            </th>
                            <th style="width: 150px;">
                                FIRST NAME
                            </th>
                            <th style="width: 150px;">
                                LAST NAME
                            </th>
                            <th style="width: 50px;">
                                REPORT ABUSES
                            </th>
                            <th style="width: 38px;">
                                Public Message
                            </th>
                            <th style="width: 38px;">
                                Private Message
                            </th>
                            <th style="width: 38px;">
                                &nbsp;
                            </th>
                        </tr>
                        <tr class="GridRow">
                            <td colspan="7" align="center" style="width: 764px; font-weight: bold">
                                No Records Found
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
