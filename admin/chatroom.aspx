<%@ Page Title="Chatroom" Language="C#" MasterPageFile="~/admin/admin_master.master"
    AutoEventWireup="true" CodeFile="~/admin/chatroom.aspx.cs" Inherits="admin_chatroom" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager runat="server" EnablePartialRendering="true" ID="ScriptManager1" />
    <script type="text/javascript">

        function uploadError(sender, args) {

        }

        function uploadComplete(sender, args) {

        }

        function ValidateImageFile(Source, args) {
            var filename = args.get_fileName();
            var filext = filename.substring(filename.lastIndexOf(".") + 1);

            if (filext == "jpg" || filext == "JPG" || filext == "jpeg" || filext == "JPEG" || filext == "png" || filext == "gif") {
                return true;
            }
            else {
                //upload cancel
                showError('Please select an image file.');
                args.set_cancel(true);

                return false;
            }
        }
    </script>
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
                Chat Rooms</h3>
        </div>
        <div class="content-box-content">
            <table style="margin: 0px auto;" border="0" cellspacing="0">
                <tr>
                    <td class="ColumnFirst">
                        <label class="lblStyle" for="txtChatRoom">
                            Chat Room<span class="ReqFields">*</span> :</label>
                    </td>
                    <td class="ColumnSecond">
                        <asp:TextBox ID="txtChatRoom" CssClass="inpText" runat="server"></asp:TextBox>
                    </td>
                    <td class="ColumnThird">
                        <asp:RequiredFieldValidator ID="reqChatRoom" runat="server" ErrorMessage="Enter ChatRoom Name"
                            ControlToValidate="txtChatRoom" CssClass="error"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="ColumnFirst">
                        <label class="lblStyle" for="txtAbout">
                            About<span class="ReqFields">*</span> :</label>
                    </td>
                    <td class="ColumnSecond">
                        <asp:TextBox ID="txtAbout" CssClass="inpText" runat="server" Height="70px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="ColumnThird">
                        <asp:RequiredFieldValidator ID="reqAbout" runat="server" ErrorMessage="Enter Something About Chatroom"
                            CssClass="error" ControlToValidate="txtAbout"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="ColumnFirst">
                        <label class="lblStyle" for="txtAbout">
                            Image<span class="ReqFields">*</span> :</label>
                    </td>
                    <td class="ColumnSecond">
                        <div style="width: 350px; position: relative;">
                            <asp:AsyncFileUpload OnClientUploadError="uploadError" OnClientUploadComplete="uploadComplete"
                                OnClientUploadStarted="ValidateImageFile" OnUploadedComplete="chatRoomImgUpload_UploadedComplete"
                                OnUploadedFileError="chatRoomImgUpload_UploadedFileError" runat="server" ID="chatRoomImgUpload"
                                Width="315px" UploaderStyle="Modern" UploadingBackColor="#CCFFFF" ThrobberID="myThrobber" />
                            <asp:Label runat="server" ID="myThrobber" Style="position: absolute; top: 5px; right: 0px;
                                display: none;"><img alt="" src="../Images/loading.gif" /></asp:Label>
                        </div>
                    </td>
                    <td class="ColumnThird">
                        <asp:Image ID="imgChatRoom" CssClass="chatroomclassBig" runat="server" Height="50px"
                            Width="50px" />
                    </td>
                </tr>
                <tr>
                    <td class="ColumnFirst" style="height: 50px;">
                        &nbsp;
                    </td>
                    <td class="ColumnSecond" style="height: 50px; vertical-align: bottom">
                        <asp:Button ID="btnSave" CssClass="myButton" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" CssClass="myButton" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            ValidationGroup="ba" />
                        <asp:HiddenField ID="hiddenId" runat="server" />
                    </td>
                    <td class="ColumnThird" style="height: 50px;">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <hr />
            <asp:GridView ID="gvChatRooms" runat="server" AutoGenerateColumns="False" CssClass="GridClass"
                AllowPaging="True" OnPageIndexChanging="gvChatRooms_PageIndexChanging" PageSize="20"
                OnRowDeleting="gvChatRooms_RowDeleting" 
                OnSelectedIndexChanging="gvChatRooms_SelectedIndexChanging">
                <Columns>
                    <asp:BoundField DataField="chat_r_id" HeaderText="CHAT ROOM ID">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ch_name" HeaderText="CHAT ROOM">
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="about" HeaderText="ABOUT">
                        <ItemStyle Width="200px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:ImageField DataImageUrlField="image">
                        <ControlStyle CssClass="chatroomclassBig" />
                    </asp:ImageField>
                    <asp:CommandField SelectText="Edit" ShowSelectButton="True" ControlStyle-CssClass="aGVLinkEdit" />
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
                                CHAT ROOM ID
                            </th>
                            <th style="width: 150px;">
                                CHAT ROOM
                            </th>
                            <th style="width: 200px;">
                                ABOUT
                            </th>
                            <th style="width: 50px;">
                                &nbsp;
                            </th>
                            <th style="width: 38px;">
                                &nbsp;
                            </th>
                            <th style="width: 38px;">
                                &nbsp;
                            </th>
                        </tr>
                        <tr class="GridRow">
                            <td colspan="6" align="center" style="width: 580px; font-weight: bold">
                                No Records Found
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
