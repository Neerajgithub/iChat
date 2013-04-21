<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        
    }

    void Session_Start(object sender, EventArgs e) 
    {
        
    }

    //CLEAR ALL LOGGED IN DETAILS OF USER JUST BEFORE SESSION TIME OUT
    void Session_End(object sender, EventArgs e)
    {
        if (Session["_di09USR"] != null)
        {
            userInfo uInfo = (userInfo)Session["_di09USR"];

            //EXIT USER FROM ANY PRE CHATROOMS
            PublicChat pObj = new PublicChat();
            pObj.User_id = uInfo.UserId;
            pObj.LeaveChatRoom();
            
            LoginCls logoutObj = new LoginCls();
            logoutObj.LogOut(uInfo.UserId);
        }
    }
       
</script>
