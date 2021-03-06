﻿using System.Web.UI.WebControls;

public class BaseAdmin : BaseUtil
{
    protected AdminInfo aInfo;

	public BaseAdmin() {}

    protected override void OnInit(System.EventArgs e)
    {
        base.OnInit(e);

        if (Context.Session != null)
        {
            if (Session["_di09ADM"] == null)
            {
                Response.Redirect(BuildPath(), true);
            }
        }
        else
        {
            Response.Redirect(BuildPath(), true);
        }
    }

    protected string BuildPath()
    {
        string path = "~/admin/login.aspx?path=" + Request.AppRelativeCurrentExecutionFilePath;
        if (Request.QueryString.Count > 0)
        {
            path += "&keys=";
            for (int i = 0; i < Request.QueryString.Count; i++)
            {
                path += Request.QueryString.GetKey(i) + "|" + Request.QueryString[i];
                if (i != (Request.QueryString.Count - 1))
                {
                    path += "$$";
                }
            }
        }
        return path;
    }

    protected void setUsername()
    {
        aInfo = (AdminInfo)Session["_di09ADM"];
        ((Label)Master.FindControl("lblUserName")).Text = aInfo.UserName;
    }
}