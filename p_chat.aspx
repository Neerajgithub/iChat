<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="p_chat.aspx.cs" Inherits="p_chat" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
<style type="text/css">
.content-box-header
{
    background:none;
    height: 50px;
}

.contLeft
{
    border-right:solid 0px #a1a1a1;
    
    padding-bottom:10px;
}
</style>
<!--[if lt IE 8]>
<style type="text/css">
.myButton 
{
    outline:0;
    padding:2px 9px;
}
</style>
<![endif]-->
<script type="text/javascript">
    function ___getPageSize() {
        var xScroll, yScroll;
        if (window.innerHeight && window.scrollMaxY) {
            xScroll = window.innerWidth + window.scrollMaxX;
            yScroll = window.innerHeight + window.scrollMaxY;
        } else if (document.body.scrollHeight > document.body.offsetHeight) { // all but Explorer Mac
            xScroll = document.body.scrollWidth;
            yScroll = document.body.scrollHeight;
        } else { // Explorer Mac...would also work in Explorer 6 Strict, Mozilla and Safari
            xScroll = document.body.offsetWidth;
            yScroll = document.body.offsetHeight;
        }
        var windowWidth, windowHeight;
        if (self.innerHeight) {	// all except Explorer
            if (document.documentElement.clientWidth) {
                windowWidth = document.documentElement.clientWidth;
            } else {
                windowWidth = self.innerWidth;
            }
            windowHeight = self.innerHeight;
        } else if (document.documentElement && document.documentElement.clientHeight) { // Explorer 6 Strict Mode
            windowWidth = document.documentElement.clientWidth;
            windowHeight = document.documentElement.clientHeight;
        } else if (document.body) { // other Explorers
            windowWidth = document.body.clientWidth;
            windowHeight = document.body.clientHeight;
        }
        // for small pages with total height less then height of the viewport
        if (yScroll < windowHeight) {
            pageHeight = windowHeight;
        } else {
            pageHeight = yScroll;
        }
        // for small pages with total width less then width of the viewport
        if (xScroll < windowWidth) {
            pageWidth = xScroll;
        } else {
            pageWidth = windowWidth;
        }
        arrayPageSize = new Array(pageWidth, pageHeight, windowWidth, windowHeight);
        return arrayPageSize;
    }

    function SetScrollPosition() {
        var obj = document.getElementById("chattingDiv");
        obj.scrollTop = obj.scrollHeight;
    }

    function postChat() {
        var msg = $("#txtMessage").val();

        if (msg != "") {
            var userid = $("#HiddenUId").val();
            var to_userid = $("#HiddenToid").val();

            $.ajax(
                {
                    type: "GET",
                    url: "p_post.ashx",
                    cache: false,
                    data: "function=post&userid=" + userid + "&to_userid=" + to_userid + "&msg=" + msg
                });
        }
        $("#txtMessage").val("");
    }

    $(document).ready(function () {
        //165 + 60
        var arrPage = ___getPageSize();
        var viewPortSize = arrPage[1] - (165 + 65);
        $("#chattingDiv").css('height', 400 + 'px');
    });

    function captureReturn(event) {
        if (event.which || event.keyCode) {
            if ((event.which == 13) || (event.keyCode == 13)) {
                postChat();
                return false;
            }
            else {
                return true;
            }
        }
    }

    function doAbuse(userid) {
        var input = "function=reportabuse&userid=" + userid;

        $.ajax({
            type: "GET",
            url: "reportabuse.ashx",
            data: input,
            cache: false,
            success: function (msg) {
                if (msg == "SUCCESS") {
                    showSucc("Report Abuse Successful");
                }
            }
        });
        return false;
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
            <div class="chatTopHead">
                <div class="chatTopAbs left">
                    <asp:Image runat="server" ID="imgUser" ImageUrl="" CssClass="chatroomclassSmall" />
                </div>
                <div class="chatTopDesc left">
                    <asp:Literal runat="server" ID="lblUserHead"></asp:Literal>
                </div>
            </div>
        </div>
        <div class="content-box-content">
            <div class="left contLeft">
            <div class="chattingWrapper">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlId="Timer1" />
                    </Triggers>
                    <ContentTemplate>
                        <div id="chattingDiv">
                        <asp:Timer ID="Timer1" Interval="2000" runat="server" ontick="Timer1_Tick" />
                        <asp:Repeater runat="server" ID="repeatChat">
                            <ItemTemplate>
                                <div class="chatUserChatDiv">
                                    <img src='<%# ResolveUrl(Eval("image").ToString()) %>' alt="" />
                                    <div>
                                        <span class="chatUserLabel"><%# Eval("online_name") + " : " %> </span>
                                        <%# Eval("message") %></div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        </div>
                        <asp:HiddenField ID="HiddenToid" runat="server" />
                        <asp:HiddenField ID="HiddenMsgid" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="chatTxtDiv">
                    <%--<asp:TextBox ID="txtMessage" Width="600px" CssClass="inpText" runat="server"></asp:TextBox>
                    <asp:Button ID="btnPost" runat="server" Text="Post" CssClass="myButton" 
                        onclick="btnPost_Click" />--%>
                    <input type="text" id="txtMessage" class="inpText" style="width:600px;" onkeydown="javascript:return captureReturn(event);" />
                    <input type="button" id="btnPost" onclick="javascript:postChat();" class="myButton" value="Post" />
                </div>
                <asp:HiddenField ID="HiddenUId" runat="server" />
            </div>
            </div>
            <div class="left contCenter">
            
            </div>
            <div class="cleaner"></div>
        </div>
    </div>
</asp:Content>

