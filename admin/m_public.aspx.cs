using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_m_public : BaseAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        setUsername();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["user"] != null)
            {
                HiddenUId.Value = Request.QueryString["user"];
                LoadUsername();
                LoadMessages();
            }
            else
            {
                ShowMessage(Message.Error,"Unable To Load Messages");
            }
        }
    }

    private void LoadUsername()
    {
        User uObj = new User();
        uObj.UserId = long.Parse(HiddenUId.Value);
        uObj.GetUserById();
        lblUser.Text = getUserName(uObj.FName, uObj.LName, uObj.Email);
    }

    public string getUserName(string fname, string lname, string email)
    {
        if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname))
        {
            if (email.Contains("@"))
            {
                return email.Split('@')[0];
            }
            else
            {
                return "";
            }
        }
        else
        {
            return fname + " " + lname;
        }
    }

    private void LoadMessages()
    {
        try
        {
            PublicChat pObj = new PublicChat();
            pObj.User_id = long.Parse(HiddenUId.Value);
            gvUserMessage.DataSource = pObj.GetUserChats();
            gvUserMessage.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvUserMessage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUserMessage.PageIndex = e.NewPageIndex;
        LoadMessages();
    }
}