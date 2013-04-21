using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class privatechat : BaseUserRedirect
{
    protected void Page_Load(object sender, EventArgs e)
    {
        setUsername();

        if (!Page.IsPostBack)
        {
            LoadLoggedUsersDetail();
        }
    }

    private void LoadLoggedUsersDetail()
    {
        try
        {
            Chat cObj = new Chat();
            chatUserList.DataSource = cObj.GetAllLoggedInUsers(uInfo.UserId);
            chatUserList.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        LoadLoggedUsersDetail();
    }
}