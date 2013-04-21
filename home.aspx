<%@ Page Title="Home" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true"
    CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .TopWrapper
        {
            background: url('Images/background.png');
        }
        
        body
        {
            background: url('Images/128.jpg');
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            if ($(".ChatRoomTabs").length < 5) {
                $(".footerWrapper").css({
                                            "position" : "absolute",
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
    <asp:Panel runat="server" ID="topPanel" CssClass="content-box">
        <div class="content-box-content">
            <div class="TopTabs">
                <div class="TabLogin left">
                    <a href="login.aspx" class="tabButton">Login</a>
                </div>
                <div class="TabRegister right">
                    <a href="register.aspx" class="tabButton">Register</a>
                </div>
                <div class="cleaner">
                </div>
            </div>
        </div>
    </asp:Panel>
    <div class="content-box">
        <div class="content-box-header">
            <h3>
                Chat Rooms</h3>
        </div>
        <div class="content-box-content">
            <div class="lowerTabs">
                <asp:Repeater runat="server" ID="chatRoomList">
                    <ItemTemplate>
                        <a href='chat.aspx?chroomid=<%# Eval("chat_r_id") %>' class="ChatRoomTabs left" title='<%# Eval("about") %>'>
                            <div class="imgPart">
                                <img src='<%# ResolveUrl(Eval("image").ToString()) %>' alt="" class="chatroomclassBig" />
                            </div>
                            <div class="headPart">
                                <p><%# Eval("ch_name") %></p>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="cleaner">
                </div>
            </div>
        </div>
    </div>
    <div class="content-box">
        <div class="content-box-content">
            <span class="descStyle"><span class="iChatStyle">iChat</span> is a chatting application
                that is all about chat and conversations. Discover endless topics with interesting
                people and dedicated chat rooms!</span>
        </div>
    </div>
</asp:Content>
