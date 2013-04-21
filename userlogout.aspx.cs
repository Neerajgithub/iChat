using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userlogout : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        if (Context.Session != null)
        {
            if (Session["_di09USR"] != null)
            {
                userInfo uInfo = (userInfo)Session["_di09USR"];

                //EXIT USER FROM ANY PRE CHATROOMS
                PublicChat pObj = new PublicChat();
                pObj.User_id = uInfo.UserId;
                pObj.LeaveChatRoom();

                LoginCls logoutObj = new LoginCls();
                logoutObj.LogOut(uInfo.UserId);
            }
        }

        Session.Abandon();
        Response.Redirect("~/home.aspx", true);
    }
}