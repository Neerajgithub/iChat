<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon"/>
    <link href="Styles/baseStyle.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 8]>
        <link href="Styles/ieStyle.css" rel="stylesheet" type="text/css" />
    <![endif]-->
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="Scripts/baseScript.js" type="text/javascript"></script>
</head>
<body style="background-color:#f9f9f9;">
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="TopWrapper">
        <div class="TopContent">
            <a href="home.aspx" title="iChat" class="Logo"></a>
        </div>
    </div>

    <style type="text/css">
.footerWrapper
{
    position: absolute;
	bottom:0px;
	width:100%;
	margin:0 auto;
}

.TopWrapper
{
    background: url('Images/background.png');
    border-bottom:solid 1px #C8C8C8;
}

body
{
    background: url('Images/128.jpg');
}
</style>
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
    <div class="LoginBox">
        <div class="LoginBoxTop">
            <span>Register</span>
        </div>
        <div class="LoginBoxCont">
            <table border="0" cellspacing="0">
                <tr>
                    <td class="LoginTblCol1">
                        <label for="txtUserName" class="lblStyle2">Your Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="inpText"></asp:TextBox>
                    </td>
                    <td class="LoginTblCol2">
                        <label class="lblStyle2" style="display:block;">&nbsp;</label>
                        <asp:RequiredFieldValidator ID="reqUsername" runat="server" 
                            ControlToValidate="txtEmail" CssClass="error" ErrorMessage="Enter Email" 
                            Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="validatEmail" runat="server" 
                        ControlToValidate="txtEmail" CssClass="error" ErrorMessage="Invalid Email" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="LoginTblCol1">
                        <label for="txtPwd" class="lblStyle2">Your Password</label>
                        <asp:TextBox ID="txtPwd" runat="server" CssClass="inpText" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="LoginTblCol2">
                        <label class="lblStyle2" style="display:block;">&nbsp;</label>
                        <asp:RequiredFieldValidator ID="reqPwd" runat="server" 
                            ControlToValidate="txtPwd" CssClass="error" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="LoginTblCol1">
                        <asp:Button ID="btnSubmit" runat="server" Text="Register" CssClass="myButton" 
                            onclick="btnSubmit_Click" />
                    </td>
                    <td class="LoginTblCol2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="LoginTblCol1">
                    </td>
                    <td class="LoginTblCol2" valign="bottom">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="LoginTblCol1">
                        &nbsp;
                    </td>
                    <td class="LoginTblCol2">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div class="footerWrapper KeepBottom">
        <div class="footerCont keepCenter">
            <div class="footerTxt">
                All rights are reserved. Copyright &copy; iChat
            </div>
        </div>
    </div>
    </form>
</body>
</html>
