<%@ WebHandler Language="C#" Class="p_post" %>

using System;
using System.Web;

public class p_post : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Request.QueryString["function"] != null && context.Request.QueryString["function"] == "post")
        {
            if (context.Request.QueryString["userid"] != null && context.Request.QueryString["to_userid"] != null && context.Request.QueryString["msg"] != null)
            {
                PrivateChat pObj = new PrivateChat();
                pObj.User_id = long.Parse(context.Request.QueryString["userid"]);
                pObj.To_user_id = long.Parse(context.Request.QueryString["to_userid"]);
                pObj.Message = context.Request.QueryString["msg"];

                pObj.PostChat();
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}