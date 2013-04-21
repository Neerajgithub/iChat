using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class home : BaseUserKeep
{
    protected void Page_Load(object sender, EventArgs e)
    {
        topPanel.Visible = !setUsername();
        LoadChatRooms();
        if (!Page.IsPostBack)
        {
            if (isLoggedIn())
            {
                //EXIT USER FROM ANY PRE CHATROOMS
                PublicChat pObj = new PublicChat();
                pObj.User_id = uInfo.UserId;
                pObj.LeaveChatRoom();
            }
        }
    }

    private void LoadChatRooms()
    {
        ChatRoom chroomObj = new ChatRoom();
        chatRoomList.DataSource = chroomObj.GetAllChatRoom();
        chatRoomList.DataBind();
    }
}