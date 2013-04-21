using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class Chat : DAO
{
	public Chat() {}

    long chat_r_id;

    public long Chat_r_id
    {
        get { return chat_r_id; }
        set { chat_r_id = value; }
    }

    public DataTable GetLoggedInUsers()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("getLoggedInUser"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "CHATROOM";
                cmd.Parameters.Add("@b_id", SqlDbType.BigInt).Value = Chat_r_id;

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

    public DataTable GetAllLoggedInUsers(long current)
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("getLoggedInUser"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "ALL";
                cmd.Parameters.Add("@u_id", SqlDbType.BigInt).Value = current;

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