using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class admin_chatroom : BaseAdmin
{
    public static string CHATROOM_SAVE_STRING = "chat_room_image";
    public static string CHATROOM_INIT_PATH = "~/Images/chatroom.png";
    public static string UPDATE = "Update";
    public static string SAVE = "Save";
    bool SAVECLICKED = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        setUsername();
        if (!Page.IsPostBack)
        {
            imgChatRoom.ImageUrl = CHATROOM_INIT_PATH;
            Session[CHATROOM_SAVE_STRING] = CHATROOM_INIT_PATH;
            LoadChatRooms();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SAVECLICKED = true;
        if (btnSave.Text == SAVE)
        {
            if (CheckFields())
            {
                ChatRoom chatrObj = new ChatRoom();
                chatrObj.Chat_name = txtChatRoom.Text;
                chatrObj.About = txtAbout.Text;
                chatrObj.Image = Session[CHATROOM_SAVE_STRING].ToString();
                if (!chatrObj.CheckChatRoom())
                {
                    if (chatrObj.AddChatRoom())
                    {
                        ShowMessage(Message.Success, "Chatroom Added Successfully.");
                        ResetPage();
                    }
                    else
                    {
                        ShowMessage(Message.Error, "Unable To Save Chatroom.");
                    }
                }
                else
                {
                    ShowMessage(Message.Warning, "Chatroom Already Exists.");
                }
            }
            else
            {
                ShowMessage(Message.Error, "Fill all required fields.");
            }
        }
        else if (btnSave.Text == UPDATE)
        {
            if (CheckFields())
            {
                ChatRoom chatrObj = new ChatRoom();
                chatrObj.Chat_r_id = int.Parse(hiddenId.Value);
                chatrObj.Chat_name = txtChatRoom.Text;
                chatrObj.About = txtAbout.Text;
                chatrObj.Image = Session[CHATROOM_SAVE_STRING].ToString();
                if (!chatrObj.CheckChatRoomEdit())
                {
                    if (chatrObj.EditChatRoom())
                    {
                        ShowMessage(Message.Success, "Chatroom Updated Successfully.");
                        ResetPage();
                    }
                    else
                    {
                        ShowMessage(Message.Error, "Unable To Update Chatroom.");
                    }
                }
                else
                {
                    ShowMessage(Message.Warning, "Chatroom Already Exists.");
                }
            }
            else
            {
                ShowMessage(Message.Error, "Fill all required fields.");
            }
        }

        imgChatRoom.ImageUrl = Session[CHATROOM_SAVE_STRING].ToString();
    }

    private void ResetPage()
    {
        txtChatRoom.Text = "";
        txtAbout.Text = "";
        btnSave.Text = SAVE;
        Session[CHATROOM_SAVE_STRING] = CHATROOM_INIT_PATH;
        LoadChatRooms();

        imgChatRoom.ImageUrl = Session[CHATROOM_SAVE_STRING].ToString();
    }

    private bool CheckFields()
    {
        bool isPgValid = true;
        if (txtChatRoom.Text.Trim().Length == 0)
        {
            isPgValid = false;
        }

        if (txtAbout.Text.Trim().Length == 0)
        {
            isPgValid = false;
        }

        return isPgValid;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ResetPage();
    }

    protected void gvChatRooms_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        hiddenId.Value = gvChatRooms.Rows[e.NewSelectedIndex].Cells[0].Text;
        txtChatRoom.Text = gvChatRooms.Rows[e.NewSelectedIndex].Cells[1].Text;
        txtAbout.Text = gvChatRooms.Rows[e.NewSelectedIndex].Cells[2].Text;
        imgChatRoom.ImageUrl = ((Image)gvChatRooms.Rows[e.NewSelectedIndex].Cells[3].Controls[0]).ImageUrl;
        Session[CHATROOM_SAVE_STRING] = imgChatRoom.ImageUrl;

        btnSave.Text = "Update";
    }

    protected void gvChatRooms_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ChatRoom chatrObj = new ChatRoom();
        chatrObj.Chat_r_id = int.Parse(gvChatRooms.Rows[e.RowIndex].Cells[0].Text);
        if (chatrObj.DeleteChatRoom())
        {
            ShowMessage(Message.Success, "Chatroom Deleted Successfully.");
            ResetPage();
        }
        else
        {
            ShowMessage(Message.Error, "Unable To Delete Chatroom.");
        }
    }

    protected void gvChatRooms_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvChatRooms.PageIndex = e.NewPageIndex;
        LoadChatRooms();
    }

    protected void chatRoomImgUpload_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "size", "top.$get(\"" + uploadResult.ClientID + "\").innerHTML = 'Uploaded size: " + AsyncFileUpload1.FileBytes.Length.ToString() + "';", true);
        if (!SAVECLICKED)
        {
            try
            {
                string savePath = Helper.GetUniqueName(e.FileName, MapPath("~/Images/chatroom/"));
                if (savePath != null)
                {
                    chatRoomImgUpload.SaveAs(savePath);

                    //string newName = "I_" + Path.GetFileName(savePath);
                    //Helper.ResizeImageFile(savePath, 50, Path.Combine(MapPath("~/Images/chatroom/"), newName));
                    string virtPath = "~/Images/chatroom/" + Path.GetFileName(savePath);
                    string finalPath = System.Web.VirtualPathUtility.ToAbsolute(virtPath);
                    Session.Add(CHATROOM_SAVE_STRING, virtPath);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "size" + new Guid(), "top.$get(\"" + imgChatRoom.ClientID + "\").setAttribute(\"src\", \"" + Server.HtmlEncode(finalPath) + "\");", true);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        else
        {
            SAVECLICKED = false;
        }
    }

    protected void chatRoomImgUpload_UploadedFileError(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "error", "top.$get(\"" + uploadResult.ClientID + "\").innerHTML = 'Error: " + e.statusMessage + "';", true);
        Console.WriteLine("Error.");
    }

    public void LoadChatRooms()
    {
        ChatRoom chrBoj = new ChatRoom();
        gvChatRooms.DataSource = chrBoj.GetAllChatRoom();
        gvChatRooms.DataBind();
    }
}