using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_home : BaseAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        setUsername();
    }
}