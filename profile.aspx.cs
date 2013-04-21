using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class profile : BaseUserRedirect
{
    public static string USER_SAVE_STRING = "chat_room_image";
    public static string USER_INIT_PATH = "~/Images/user1.png";
    public static string DEFAULTGEN = "Select";
    bool SAVECLICKED = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        setUsername();
        if (!Page.IsPostBack)
        {
            //EXIT USER FROM ANY PRE CHATROOMS
            PublicChat pObj = new PublicChat();
            pObj.User_id = uInfo.UserId;
            pObj.LeaveChatRoom();

            //LOAD ALL DETAILS
            Session[USER_SAVE_STRING] = USER_INIT_PATH;
            LoadUserDetails();
            imgUser.ImageUrl = Session[USER_SAVE_STRING].ToString();
        }
    }

    private void LoadUserDetails()
    {
        User userObj = new User();
        userObj.UserId = uInfo.UserId;
        if (userObj.GetUserById())
        {
            lblEmail.Text = userObj.Email;
            txtFName.Text = userObj.FName;
            txtLName.Text = userObj.LName;
            txtDOB.Text = userObj.DOB;
            if (!string.IsNullOrEmpty(userObj.GetGen))
            {
                switch (userObj.GetGen)
                {
                    case "F":
                        ddlGender.Text = "Female";
                        break;
                    case "M":
                        ddlGender.Text = "Male";
                        break;
                    default:
                        ddlGender.Text = DEFAULTGEN;
                        break;
                }
            }
            txtAbout.Text = userObj.About;
            Session[USER_SAVE_STRING] = userObj.Image;
        }
        else
        {
            ShowMessage(Message.Error, "Unable To Load Profile.");
        }
    }

    private void ResetPage()
    {
        Session[USER_SAVE_STRING] = USER_INIT_PATH;
        LoadUserDetails();
        imgUser.ImageUrl = Session[USER_SAVE_STRING].ToString();
    }

    private bool CheckFields()
    {
        bool isPgValid = true;
        if (txtDOB.Text.Trim().Length != 0)
        {
            if (CheckDate())
            {
                isPgValid = true;
            }
            else
            {
                isPgValid = false;
            }
        }
        else
        {
            isPgValid = true;
        }

        return isPgValid;
    }

    public bool CheckDate()
    {
        try
        {
            DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", null);
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SAVECLICKED = true;
        if (CheckFields())
        {
            User userObj = new User();
            userObj.UserId = uInfo.UserId;
            userObj.FName = txtFName.Text;
            userObj.LName = txtLName.Text;
            if (txtDOB.Text.Trim().Length != 0)
            {
                userObj.DOB = txtDOB.Text;
            }
            if (ddlGender.Text != DEFAULTGEN)
            {
                userObj.Gen = ddlGender.Text;
            }
            else
            {
                userObj.Gen = "";
            }
            userObj.About = txtAbout.Text;
            userObj.Image = Session[USER_SAVE_STRING].ToString();
            if (userObj.EditUser())
            {
                ShowMessage(Message.Success, "Profile Updated Successfully.");
                ResetPage();
            }
            else
            {
                ShowMessage(Message.Error, "Unable To Updated Profile.");
            }
        }
        else
        {
            ShowMessage(Message.Error, "Fill valid DOB.");
        }

        imgUser.ImageUrl = Session[USER_SAVE_STRING].ToString();
    }

    protected void chatRoomImgUpload_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        if (!SAVECLICKED)
        {
            try
            {
                string savePath = Helper.GetUniqueNameUser(e.FileName, MapPath("~/Images/user/"));
                if (savePath != null)
                {
                    //chatRoomImgUpload.SaveAs(savePath);

                    //string newName = "I_" + Path.GetFileName(savePath);
                    //Helper.ResizeImageFile(savePath, 50, Path.Combine(MapPath("~/Images/chatroom/"), newName));
                    /********************************************************/
                    HttpPostedFile file = chatRoomImgUpload.PostedFile;
                    ImageResizer.ImageJob i = new ImageResizer.ImageJob(file, savePath, new ImageResizer.ResizeSettings("width=50;height=50;format=jpg;mode=pad"));
                    i.CreateParentDirectory = true; //Auto-create the uploads directory.
                    i.Build();
                    /********************************************************/
                    string virtPath = "~/Images/user/" + Path.GetFileName(savePath);
                    string finalPath = System.Web.VirtualPathUtility.ToAbsolute(virtPath);
                    Session.Add(USER_SAVE_STRING, virtPath);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "size" + new Guid(), "top.$get(\"" + imgUser.ClientID + "\").setAttribute(\"src\", \"" + Server.HtmlEncode(finalPath) + "\");", true);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.StackTrace);
            }
        }
        else
        {
            SAVECLICKED = false;
        }
    }

    protected void chatRoomImgUpload_UploadedFileError(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        Console.WriteLine("Error.");
    }
}