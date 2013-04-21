<%@ Page Title="Home" Language="C#" MasterPageFile="~/admin/admin_master.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="admin_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
.footerWrapper
{
    position: absolute;
	bottom:0px;
	width:100%;
	margin:0 auto;
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
    <div class="content-box">
        <div class="content-box-content">
            <h2 class="lblStyle" style="font-size:18px; text-align:center; letter-spacing:3px; word-spacing:10px;">Welcome To iChat Admin Panel</h2>
        </div>
    </div>
</asp:Content>

