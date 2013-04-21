<%@ Page Title="Users" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="privatechat.aspx.cs" Inherits="privatechat" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
<style type="text/css">
.ChatRoomTabs
{
    position:relative;
    color:#222;
    display:block;
    width: 400px;
    height: 50px;
    margin-left:50px;
    margin-top:20px;
    background-color:#EEEEEE;
    border:solid 2px #ccc;
    -webkit-border-radius: 6px;
    -moz-border-radius: 6px;
    border-radius: 6px;
    overflow:hidden;
}

.ChatRoomTabs:hover
{
    background-color:#DDE8F0;
    border-color: #a1a1a1;
}

.ChatRoomTabs .imgPart
{
    position:absolute;
    display:block;
    top:5px;
    left:5px;
}

.chatroomclassBig
{
    -webkit-border-radius: 6px;
    -moz-border-radius: 6px;
    border-radius: 6px;
    height:40px;
    width:40px;
}

.ChatRoomTabs .headPart
{
   margin-left:70px;
   font-size:16px;
   font-weight:bold;
}
</style>
<script type="text/javascript">
    $(document).ready(function () {
        if ($(".ChatRoomTabs").length < 11) {
            $(".footerWrapper").css({
                "position": "absolute",
                "bottom": "0px",
                "width": "100%",
                "margin": "0 auto"
            });
        }
    });
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
                Users</h3>
        </div>
        <div class="content-box-content">
            <div class="lowerTabs">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlId="Timer1" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:Timer ID="Timer1" Interval="3000" runat="server" ontick="Timer1_Tick" />
                        <asp:Repeater runat="server" ID="chatUserList">
                            <ItemTemplate>
                                <a href='p_chat.aspx?userid=<%# Eval("user_id") %>' class="ChatRoomTabs left" title="">
                                    <div class="imgPart">
                                        <img src='<%# ResolveUrl(Eval("image").ToString()) %>' alt="" class="chatroomclassBig" />
                                    </div>
                                    <div class="headPart">
                                        <p><%# Eval("online_name")%></p>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="cleaner">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

