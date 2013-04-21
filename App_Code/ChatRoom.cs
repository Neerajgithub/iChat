using System.Data;
using System.Data.SqlClient;
using System;
public class ChatRoom : DAO
{
	public ChatRoom() {}


    #region PROPERTIES
    private long _chat_r_id;
    public long Chat_r_id
    {
        get { return _chat_r_id; }
        set { _chat_r_id = value; }
    }

    private string _chat_name;
    public string Chat_name
    {
        get { return _chat_name; }
        set { _chat_name = value; }
    }

    private string _about;
    public string About
    {
        get { return _about; }
        set { _about = value; }
    }

    string image;

    public string Image
    {
        get { return image; }
        set { image = value; }
    }

    string simage;

    public string SImage
    {
        get { return simage; }
        set { simage = value; }
    }
    #endregion

    public bool AddChatRoom()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("chat_Room_AUD"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "ADD";
                cmd.Parameters.Add("@ch_name", SqlDbType.VarChar).Value = Chat_name;
                cmd.Parameters.Add("@about", SqlDbType.VarChar).Value = About;
                cmd.Parameters.Add("@image", SqlDbType.VarChar).Value = Image;
                cmd.Parameters.Add("@s_image", SqlDbType.VarChar).Value = SImage;

                int row = doAddUpdateDelete(cmd);
                if (row > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool EditChatRoom()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("chat_Room_AUD"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "UPDATE";
                cmd.Parameters.Add("@chat_r_id", SqlDbType.BigInt).Value = Chat_r_id;
                cmd.Parameters.Add("@ch_name", SqlDbType.VarChar).Value = Chat_name;
                cmd.Parameters.Add("@about", SqlDbType.VarChar).Value = About;
                cmd.Parameters.Add("@image", SqlDbType.VarChar).Value = Image;
                cmd.Parameters.Add("@s_image", SqlDbType.VarChar).Value = SImage;

                int row = doAddUpdateDelete(cmd);
                if (row > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool DeleteChatRoom()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("chat_Room_AUD"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "DELETE";
                cmd.Parameters.Add("@chat_r_id", SqlDbType.BigInt).Value = Chat_r_id;

                int row = doAddUpdateDelete(cmd);
                if (row > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public DataTable GetAllChatRoom()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("chat_Room_Get"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "GETALL";

                DataTable dTable = getData(cmd);
                if (dTable.Rows.Count > 0)
                {
                    return dTable;
                }
                else
                {
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool GetChatRoomById()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("chat_Room_Get"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "GETBYID";
                cmd.Parameters.Add("@chat_r_id", SqlDbType.BigInt).Value = Chat_r_id;

                DataTable dTable = getData(cmd);
                if (dTable.Rows.Count > 0)
                {
                    Chat_name = dTable.Rows[0]["ch_name"].ToString();
                    About = dTable.Rows[0]["about"].ToString();
                    Image = dTable.Rows[0]["image"].ToString();
                    SImage = dTable.Rows[0]["s_image"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool CheckChatRoom()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("chat_Room_Get"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "CHECKCHATROOM";
                cmd.Parameters.Add("@ch_name", SqlDbType.VarChar).Value = Chat_name;

                DataTable dTable = getData(cmd);
                if (dTable.Rows.Count > 0)
                {
                    return Convert.ToBoolean(dTable.Rows[0]["IS_EXISTS"]);
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool CheckChatRoomEdit()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("chat_Room_Get"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "CHECKCHATROOMEDIT";
                cmd.Parameters.Add("@chat_r_id", SqlDbType.VarChar).Value = Chat_r_id;
                cmd.Parameters.Add("@ch_name", SqlDbType.VarChar).Value = Chat_name;

                DataTable dTable = getData(cmd);
                if (dTable.Rows.Count > 0)
                {
                    return Convert.ToBoolean(dTable.Rows[0]["IS_EXISTS"]);
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}