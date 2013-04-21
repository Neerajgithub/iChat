using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class login : LoggedInRedirect
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (CheckFields())
        {
            LoginCls LogObj = new LoginCls(txtUserName.Text, txtPwd.Text);
            switch (LogObj.CheckLogin("user"))
            {
                case users.Anonymous:
                    ShowMessage(Message.Error, "Invalid Username Or Password.");
                    break;
                case users.User:
                    Session.Add("_di09USR", LogObj.UInfo);
                    Response.Redirect(GetPath(LogObj.ProfilePage), true);
                    //if (hiddenSource.Value != "" && File.Exists(Server.MapPath(hiddenSource.Value)))
                    //{
                    //    Response.Redirect(hiddenSource.Value, true);
                    //}
                    //else
                    //{
                    //    Response.Redirect(LogObj.ProfilePage, true);
                    //}
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
}