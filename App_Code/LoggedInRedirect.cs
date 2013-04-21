using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class LoggedInRedirect : BaseUtil
{
    public LoggedInRedirect() { }

    protected override void OnInit(System.EventArgs e)
    {
        base.OnInit(e);

        if (Context.Session != null)
        {
            if (Session["_di09USR"] != null)
            {
                Response.Redirect("~/home.aspx", true);
            }
        }
    }
}