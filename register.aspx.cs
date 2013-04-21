using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : LoggedInRedirect
{
    public static string USER_INIT_PATH = "~/Images/user1.png";

    protected void Page_Load(object sender, EventArgs e)
    {
        txtEmail.Focus();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        RegisterUser();
    }

    private bool CheckPage()
    {
        bool isPgValid = true;
        if (txtEmail.Text.Trim().Length == 0)
        {
            isPgValid = false;
        }

        if (txtPwd.Text.Trim().Length == 0)
        {
            isPgValid = false;
        }

        return isPgValid;
    }

    public void RegisterUser()
    {
        if (CheckPage())
        {
            User UserObj = new User();
            UserObj.Email = txtEmail.Text;
            UserObj.Password = txtPwd.Text;
            UserObj.Image = USER_INIT_PATH;
            if (!UserObj.CheckUser())
            {
                if (UserObj.RegUser())
                {
                    //userInfo uInfo = new userInfo();
                    //uInfo.UserId = UserObj.UserId;
                    //uInfo.UserName = getUserName(UserObj.Email);
                    //Session.Add("_di09USR", uInfo);

                    //Response.Redirect("~/home.aspx", true);

                    LoginCls LogObj = new LoginCls(UserObj.Email, UserObj.GetPassword);
                    switch (LogObj.CheckLogin("user"))
                    {
                        case users.Anonymous:
                            ShowMessage(Message.Error, "Invalid Username Or Password.");
                            break;
                        case users.User:
                            Session.Add("_di09USR", LogObj.UInfo);
                            Response.Redirect(LogObj.ProfilePage, true);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    ShowMessage(Message.Error, "Unable To Register.");
                }
            }
            else
            {
                ShowMessage(Message.Warning, "Email Already Exists.");
            }
        }
        else
        {
            ShowMessage(Message.Error, "Fill all fields.");
        }
    }

    private void ResetPage()
    {
        txtEmail.Text = string.Empty;
    }

    public string getUserName(string email)
    {
        if (email.Contains("@"))
        {
            return email.Split('@')[0];
        }
        else
        {
            return email;
        }
    }
}