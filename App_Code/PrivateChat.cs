using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class PrivateChat : DAO
{
	public PrivateChat() {}

    private long msg_id, user_id, to_user_id;

    public long To_user_id
    {
        get { return to_user_id; }
        set { to_user_id = value; }
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
            using (SqlCommand cmd = new SqlCommand("privateChat"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "INITCHAT";
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = User_id;
                cmd.Parameters.Add("@to_user_id", SqlDbType.BigInt).Value = To_user_id;

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
            using (SqlCommand cmd = new SqlCommand("privateChat"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "NEWCHAT";
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = User_id;
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
            using (SqlCommand cmd = new SqlCommand("userPrivateChat"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "ADD";
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = User_id;
                cmd.Parameters.Add("@to_user_id", SqlDbType.BigInt).Value = To_user_id;
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

    public DataTable GetUserChats()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("userPrivateChat"))
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