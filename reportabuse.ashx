<%@ WebHandler Language="C#" Class="reportabuse" %>

using System;
using System.Web;

public class reportabuse : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        try
        {
            if (context.Request.QueryString["function"] != null && context.Request.QueryString["function"] == "reportabuse")
            {
                if (context.Request.QueryString["userid"] != null)
                {
                    User uObj = new User();
                    uObj.UserId = long.Parse(context.Request.QueryString["userid"]);
                    if (uObj.ReportAbuseUser())
                    {
                        context.Response.Write("SUCCESS");
                    }
                    else
                    {
                        context.Response.Write("ERROR");
                    }
                }
                else
                {
                    context.Response.Write("ERROR");
                }
            }
            else
            {
                context.Response.Write("ERROR");
            }
        }
        catch
        {
            context.Response.Write("ERROR");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}