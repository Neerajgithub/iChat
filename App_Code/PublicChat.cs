using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class PublicChat : DAO
{
	public PublicChat() {}

    private long msg_id, user_id, chat_r_id;

    public long Chat_r_id
    {
        get { return chat_r_id; }
        set { chat_r_id = value; }
    }

    public long User_id
    {
        get { return user_id; }
        set { user_id = value; }
    }

    public long Msg_id
    {
        get { return msg_id; }
        set { msg_id = value; }
    }

    private string message, time;

    public string Time
    {
        get { return time; }
        set { time = value; }
    }

    public string Message
    {
        get { return message; }
        set { message = value; }
    }

    public DataTable GetInitChat()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("publicChat"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "INITCHAT";
                cmd.Parameters.Add("@ch_r_id", SqlDbType.BigInt).Value = Chat_r_id;

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

    public DataTable GetChats()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("publicChat"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "NEWCHAT";
                cmd.Parameters.Add("@ch_r_id", SqlDbType.BigInt).Value = Chat_r_id;
                cmd.Parameters.Add("@m_id", SqlDbType.BigInt).Value = Msg_id;

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

    public bool PostChat()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("userPublicChat"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "ADD";
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = User_id;
                cmd.Parameters.Add("@chat_r_id", SqlDbType.BigInt).Value = Chat_r_id;
                cmd.Parameters.Add("@message", SqlDbType.Text).Value = Message;

                int i = doAddUpdateDelete(cmd);
                if (i > 0)
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

    public bool JoinChatRoom()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("joinChatRoom"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "JOIN";
                cmd.Parameters.Add("@ch_r_id", SqlDbType.BigInt).Value = Chat_r_id;
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = User_id;

                int i = doAddUpdateDelete(cmd);
                if (i > 0)
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

    public bool LeaveChatRoom()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("joinChatRoom"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "UNJOIN";
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = User_id;

                int i = doAddUpdateDelete(cmd);
                if (i > 0)
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

    public DataTable GetUserChats()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("userPublicChat"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "GETUSERMESSAGE";
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = User_id;

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
}