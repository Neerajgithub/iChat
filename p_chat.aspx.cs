using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class p_chat : BaseUserRedirect
{
    protected void Page_Load(object sender, EventArgs e)
    {
        setUsername();

        if (Request.QueryString["userid"] != null)
        {
            HiddenToid.Value = Request.QueryString["userid"];
            HiddenUId.Value = uInfo.UserId.ToString();
            if (LoadUserDetail())
            {
                //JoinChatRoom();
                LoadInitMessage();

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "SHOWMSGINFO" + new Guid(), "javascript:SetScrollPosition();", true);
            }
            else
            {
                ShowMessage(Message.Error, "Unable To Load Chatroom.");
            }
        }
        else
        {
            ShowMessage(Message.Error, "Unable To Load Chatroom.");
        }
    }

    private bool LoadUserDetail()
    {
        try
        {
            User uObj = new User();
            uObj.UserId = long.Parse(HiddenToid.Value);
            if (uObj.GetChatUser())
            {
                lblUserHead.Text = uObj.Online_name;
                imgUser.ImageUrl = uObj.Image;
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    private void LoadInitMessage()
    {
        PrivateChat pObj = new PrivateChat();
        pObj.User_id = long.Parse(HiddenUId.Value);
        pObj.To_user_id = long.Parse(HiddenToid.Value);
        DataTable dTable = new DataTable();
        dTable = pObj.GetInitChat();
        if (dTable != null)
        {
            object val = null;
            val = dTable.Rows[0]["msg_id"];
            if (val != null)
            {
                HiddenMsgid.Value = val.ToString();
            }
            else
            {
                HiddenMsgid.Value = "0";
            }
        }
        else
        {
            HiddenMsgid.Value = "0";
        }

        repeatChat.DataSource = dTable;
        repeatChat.DataBind();
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {

    }
}