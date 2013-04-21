using System;
using System.Web.UI;

public class BaseUtil : System.Web.UI.Page
{
	public BaseUtil() { }

    protected void ShowMessage(Message msg, string str)
    {
        switch (msg)
        {
            case Message.Info:
                ClientScript.RegisterStartupScript(this.GetType(), "SHOWMSGINFO" + new Guid(), "javascript:showInfo('" + Server.HtmlEncode(str) + "');", true);
                break;
            case Message.Error:
                ClientScript.RegisterStartupScript(this.GetType(), "SHOWMSGERROR" + new Guid(), "javascript:showError('" + Server.HtmlEncode(str) + "');", true);
                break;
            case Message.Warning:
                ClientScript.RegisterStartupScript(this.GetType(), "SHOWMSGWARNING" + new Guid(), "javascript:showWarn('" + Server.HtmlEncode(str) + "');", true);
                break;
            case Message.Success:
                ClientScript.RegisterStartupScript(this.GetType(), "SHOWMSGSUCCESS" + new Guid(), "javascript:showSucc('" + Server.HtmlEncode(str) + "');", true);
                break;
            default:
                break;
        }
    }

    protected void ShowMessage1(Message msg, string str)
    {
        switch (msg)
        {
            case Message.Info:
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SHOWMSGINFO" + new Guid(), "javascript:showInfo('" + Server.HtmlEncode(str) + "');", true);
                break;
            case Message.Error:
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SHOWMSGERROR" + new Guid(), "javascript:showError('" + Server.HtmlEncode(str) + "');", true);
                break;
            case Message.Warning:
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SHOWMSGWARNING" + new Guid(), "javascript:showWarn('" + Server.HtmlEncode(str) + "');", true);
                break;
            case Message.Success:
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SHOWMSGSUCCESS" + new Guid(), "javascript:showSucc('" + Server.HtmlEncode(str) + "');", true);
                break;
            default:
                break;
        }
    }
}