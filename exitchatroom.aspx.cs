using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class exitchatroom : BaseUserRedirect
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            uInfo = (userInfo)Session["_di09USR"];
            PublicChat pObj = new PublicChat();
            pObj.User_id = uInfo.UserId;
            pObj.LeaveChatRoom();
        }
        finally
        {
            Response.Redirect("~/home.aspx");
        }
    }
}