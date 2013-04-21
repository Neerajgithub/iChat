using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class chat : BaseUserRedirect
{
    protected void Page_Load(object sender, EventArgs e)
    {
        setUsername();
        if (Request.QueryString["chroomid"] != null)
        {
            HiddenCid.Value = Request.QueryString["chroomid"];
            HiddenUId.Value = uInfo.UserId.ToString();
            if (LoadChatRoomDetail())
            {
                JoinChatRoom();
                LoadLoggedUsersDetail();
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

    private void JoinChatRoom()
    {
        try
        {
            PublicChat pObj = new PublicChat();
            pObj.Chat_r_id = long.Parse(HiddenCid.Value);
            pObj.User_id = uInfo.UserId;
            pObj.JoinChatRoom();
        }
        catch (Exception ex)
        {

        }
    }

    private void LoadLoggedUsersDetail()
    {
        try
        {
            Chat cObj = new Chat();
            cObj.Chat_r_id = long.Parse(HiddenCid.Value);

            chatUserList.DataSource = cObj.GetLoggedInUsers();
            chatUserList.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    private bool LoadChatRoomDetail()
    {
        try
        {
            ChatRoom chrObj = new ChatRoom();
            chrObj.Chat_r_id = long.Parse(HiddenCid.Value);
            if (chrObj.GetChatRoomById())
            {
                lblChatRoomHead.Text = chrObj.Chat_name;
                imgChatRoom.ImageUrl = chrObj.Image;
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

    public string getUserName(object fnm, object lnm, object eml)
    {
        string fname = fnm.ToString();
        string lname = lnm.ToString();
        string email = eml.ToString();
        if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname))
        {
            if (email.Contains("@"))
            {
                return email.Split('@')[0];
            }
            else
            {
                return "";
            }
        }
        else
        {
            return fname + " " + lname;
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //lblDate.Text += DateTime.Now.ToString() + "<br /><br /><br /><br /><br /><br />";
        LoadChatData();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "SHOWMSGINFO" + new Guid(), "javascript:SetScrollPosition();", true);
    }

    private void LoadChatData()
    {
        PublicChat pObj = new PublicChat();
        pObj.Chat_r_id = long.Parse(HiddenCid.Value);
        pObj.Msg_id = long.Parse(HiddenMsgid.Value);

        repeatChat.DataSource = pObj.GetChats();
        repeatChat.DataBind();
    }

    private void LoadInitMessage()
    {
        PublicChat pObj = new PublicChat();
        pObj.Chat_r_id = long.Parse(HiddenCid.Value);
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

    protected void btnPost_Click(object sender, EventArgs e)
    {
        //if (txtMessage.Text.Trim().Length != 0)
        //{
        //    PublicChat pObj = new PublicChat();
        //    pObj.User_id = uInfo.UserId;
        //    pObj.Chat_r_id = int.Parse(hiddenCid.Value);
        //    pObj.Message = txtMessage.Text;
        //    pObj.PostChat();
        //    txtMessage.Text = "";
        //}
    }
}