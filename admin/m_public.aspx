<%@ Page Title="Public Messages" Language="C#" MasterPageFile="~/admin/admin_master.master" AutoEventWireup="true" CodeFile="m_public.aspx.cs" Inherits="admin_m_public" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <h3>Public Messages</h3>
        </div>
        <div class="content-box-content">
            <a href="users.aspx" class="aGVLinkEdit" title="Back To Users">Back To Users</a><br />
            <asp:Label ID="lblUser" runat="server" CssClass="lblStyle" Text="" style="line-height:40px; font-weight:bold; padding-left:20px;"></asp:Label>
            <asp:GridView ID="gvUserMessage" runat="server" AutoGenerateColumns="False" CssClass="GridClass"
                AllowPaging="True" OnPageIndexChanging="gvUserMessage_PageIndexChanging" 
                PageSize="60">
                <Columns>
                    <asp:BoundField DataField="ch_name" HeaderText="CHAT ROOM">
                        <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="message" HeaderText="MESSAGE">
                        <ItemStyle Width="500px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="time" HeaderText="TIME">
                        <ItemStyle Width="150px" HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
                <HeaderStyle CssClass="GridHead" />
                <RowStyle CssClass="GridRow" />
                <SelectedRowStyle CssClass="GridRowSelected" />
                <EmptyDataTemplate>
                    <table class="GridClass" cellspacing="0" rules="all" border="0" style="border-collapse: collapse;">
                        <tr class="GridHead">
                            <th style="width: 200px;">
                                CHAT ROOM
                            </th>
                            <th style="width: 500px;">
                                MESSAGE
                            </th>
                            <th style="width: 150px;">
                                TIME
                            </th>
                        </tr>
                        <tr class="GridRow">
                            <td colspan="3" align="center" style="width: 850px; font-weight: bold">
                                No Records Found
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:HiddenField ID="HiddenUId" runat="server" />
        </div>
    </div>
</asp:Content>

