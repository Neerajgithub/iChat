using System.Web.UI.WebControls;

public class BaseUserKeep : BaseUtil
{
    protected userInfo uInfo;

    protected static string DEFAULTUSER = "Guest";

	public BaseUserKeep() {}

    protected bool setUsername()
    {
        if (isLoggedIn())
        {
            uInfo = (userInfo)Session["_di09USR"];
            ((Label)Master.FindControl("lblUserName")).Text = uInfo.UserName;
            ((HyperLink)Master.FindControl("linkProfile")).Visible = true;
            ((HyperLink)Master.FindControl("linkLogout")).Visible = true;
            ((HyperLink)Master.FindControl("linkPrivate")).Visible = true;
            return true;
        }
        else
        {
            ((Label)Master.FindControl("lblUserName")).Text = DEFAULTUSER;
            ((HyperLink)Master.FindControl("linkProfile")).Visible = false;
            ((HyperLink)Master.FindControl("linkLogout")).Visible = false;
            ((HyperLink)Master.FindControl("linkPrivate")).Visible = false;
            return false;
        }
    }

    protected bool isLoggedIn()
    {
        if (Context.Session != null)
        {
            if (Session["_di09USR"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
}