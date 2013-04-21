<%@ Page Title="Profile" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ToolkitScriptManager runat="server" EnablePartialRendering="true" ID="ScriptManager1" />
<style type="text/css">
.footerWrapper
{
    position: absolute;
	bottom:0px;
	width:100%;
	margin:0 auto;
}

.ColumnFirst
{
    width:200px;
    height:35px;
    border:solid 0px #000;
    padding-right:10px;
    text-align:right;
}   

.ColumnSecond
{
    width:225px;
    height:35px;
    border:solid 0px #000;
    text-align:left;
}

.ColumnThird
{
    width:100px;
    height:35px;
    border:solid 0px #000;
    text-align:left;
}

.ColumnFourth
{
    width:220px;
    height:35px;
    border:solid 0px #000;
    text-align:left;
    vertical-align:top;
}
</style>
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
                Profile</h3>
        </div>
        <div class="content-box-content">
            <table style="margin: 0px auto;" border="0" cellspacing="0">
                <tr>
                    <td class="ColumnFirst">
                        <label class="lblStyle" for="txtAbout">
                            Email<span class="ReqFields">&nbsp;</span> :</label>
                    </td>
                    <td class="ColumnSecond">
                        <asp:Label ID="lblEmail" runat="server" Text="" CssClass="lblStyle" Font-Bold="true"></asp:Label>
                    </td>
                    <td class="ColumnThird">
                        &nbsp;
                    </td>
                    <td class="ColumnFourth" rowspan="3">
                        <asp:Image ID="imgUser" CssClass="chatroomclassBig" runat="server" Height="50px"
                            Width="50px" ImageUrl="" /><br /><br />
                        <div style="width: 235px; position: relative;">
                            <asp:AsyncFileUpload OnClientUploadError="uploadError" OnClientUploadComplete="uploadComplete"
                                OnClientUploadStarted="ValidateImageFile" OnUploadedComplete="chatRoomImgUpload_UploadedComplete"
                                OnUploadedFileError="chatRoomImgUpload_UploadedFileError" runat="server" ID="chatRoomImgUpload"
                                Width="200px" UploaderStyle="Modern" UploadingBackColor="#CCFFFF" ThrobberID="myThrobber" />
                            <asp:Label runat="server" ID="myThrobber" Style="position: absolute; top: 5px; right: 0px;
                                display: none;"><img alt="" src="Images/loading.gif" /></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="ColumnFirst">
                        <label class="lblStyle" for="txtFName">
                            First Name<span class="ReqFields">&nbsp;</span> :</label>
                    </td>
                    <td class="ColumnSecond">
                        <asp:TextBox ID="txtFName" CssClass="inpText" runat="server"></asp:TextBox>
                    </td>
                    <td class="ColumnThird">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="ColumnFirst">
                        <label class="lblStyle" for="txtLName">
                            Last Name<span class="ReqFields">&nbsp;</span> :</label>
                    </td>
                    <td class="ColumnSecond">
                        <asp:TextBox ID="txtLName" CssClass="inpText" runat="server"></asp:TextBox>
                    </td>
                    <td class="ColumnThird">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="ColumnFirst">
                        <label class="lblStyle" for="txtLName">
                            DOB<span class="ReqFields">&nbsp;</span> :</label>
                    </td>
                    <td class="ColumnSecond">
                        <asp:TextBox ID="txtDOB" runat="server" CssClass="inpText"></asp:TextBox>                        
                        <asp:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txtDOB" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </td>
                    <td class="ColumnThird">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="ColumnFirst">
                        <label class="lblStyle" for="txtLName">
                            Gender<span class="ReqFields">&nbsp;</span> :</label>
                    </td>
                    <td class="ColumnSecond">
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="dropList" 
                            Width="150px">
                            <asp:ListItem Selected="True">Select</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="ColumnThird">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="ColumnFirst">
                        <label class="lblStyle" for="txtAbout">
                            About<span class="ReqFields">&nbsp;</span> :</label>
                    </td>
                    <td class="ColumnSecond">
                        <asp:TextBox ID="txtAbout" CssClass="inpText" runat="server" Height="70px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="ColumnThird">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="ColumnFirst" style="height: 50px;">
                        &nbsp;
                    </td>
                    <td class="ColumnSecond" style="height: 50px; vertical-align: bottom">
                        <asp:Button ID="btnSave" CssClass="myButton" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </td>
                    <td class="ColumnThird" style="height: 50px;">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

