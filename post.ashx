<%@ WebHandler Language="C#" Class="post" %>

using System;
using System.Web;

public class post : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Request.QueryString["function"] != null && context.Request.QueryString["function"] == "post")
        {
            if (context.Request.QueryString["userid"] != null && context.Request.QueryString["chat_r"] != null && context.Request.QueryString["msg"] != null)
            {
                PublicChat pObj = new PublicChat();
                pObj.User_id = long.Parse(context.Request.QueryString["userid"]);
                pObj.Chat_r_id = long.Parse(context.Request.QueryString["chat_r"]);
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