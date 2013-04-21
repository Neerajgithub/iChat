<%@ Page Title="Chatrooms" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="chatroom.aspx.cs" Inherits="chatroom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
</asp:Content>

