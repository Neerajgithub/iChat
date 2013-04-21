using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_users : BaseAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        setUsername();
        if (!Page.IsPostBack)
        {
            LoadUserDetails();
        }
    }

    private void LoadUserDetails()
    {
        User userObj = new User();
        gvUsers.DataSource = userObj.GetAllUser();
        gvUsers.DataBind();
    }

    protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        User userObj = new User();
        userObj.UserId = int.Parse(gvUsers.Rows[e.RowIndex].Cells[0].Text);
        if (userObj.DeleteUser())
        {
            ShowMessage(Message.Success, "User Deleted Successfully.");
            ResetPage();
        }
        else
        {
            ShowMessage(Message.Error, "Unable To Delete User.");
        }
    }

    private void ResetPage()
    {
        LoadUserDetails();
    }

    protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUsers.PageIndex = e.NewPageIndex;
        LoadUserDetails();
    }
}