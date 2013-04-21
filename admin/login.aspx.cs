using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class admin_login : LoggedInRedirectAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtUserName.Focus();
            if (Request.QueryString["path"] != null)
            {
                RestorePath();
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (CheckFields())
        {
            LoginCls LogObj = new LoginCls(txtUserName.Text, txtPwd.Text);
            switch (LogObj.CheckLogin("admin"))
            {
                case users.Anonymous:
                    ShowMessage(Message.Error, "Invalid Username Or Password.");
                    break;
                case users.Admin:
                    Session.Add("_di09ADM", LogObj.AInfo);
                    Response.Redirect(GetPath(LogObj.ProfilePage), true);
                    break;
                default:
                    break;
            }
        }
        else
        {
            ShowMessage(Message.Error, "Fill all required fields.");
        }
    }

    private bool CheckFields()
    {
        bool isPgValid = true;
        if (txtUserName.Text.Trim().Length == 0)
        {
            isPgValid = false;
        }

        if (txtPwd.Text.Trim().Length == 0)
        {
            isPgValid = false;
        }

        return isPgValid;
    }

    private void ShowMessage(Message msg, string str)
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

    private void RestorePath()
    {
        hiddenSource.Value = Request.QueryString["path"];
        if (Request.QueryString["keys"] != null)
        {
            string keys = Request.QueryString["keys"];
            keys = keys.Replace("|", "=");
            keys = keys.Replace("$$", "&");
            HiddenKeys.Value = keys;
        }
    }

    private string GetPath(string defaultStr)
    {
        if (!string.IsNullOrEmpty(hiddenSource.Value))
        {
            if (File.Exists(Server.MapPath(hiddenSource.Value)))
            {
                string pathStr = hiddenSource.Value;
                if (!string.IsNullOrEmpty(HiddenKeys.Value))
                {
                    pathStr += ("?" + HiddenKeys.Value);
                }
                return pathStr;
            }
            else
            {
                return defaultStr;
            }
        }
        else
        {
            return defaultStr;
        }
    }
}