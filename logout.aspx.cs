using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/home.aspx", true);
    }
}