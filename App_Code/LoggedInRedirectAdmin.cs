using System;
using System.Web.UI;
public class LoggedInRedirectAdmin : BaseUtil
{
    public LoggedInRedirectAdmin() { }

    protected override void OnInit(System.EventArgs e)
    {
        base.OnInit(e);

        if (Context.Session != null)
        {
            if (Session["_di09ADM"] != null)
            {
                Response.Redirect("~/admin/home.aspx", true);
            }
        }
    }
}