using System;
using System.Data.SqlClient;
using System.Data;
public class User : DAO
{
    public User() { }

    #region PROPERTIES

    private long _userId = 0;

    public long UserId
    {
        get { return _userId; }
        set { _userId = value; }
    }

    private string _Fname;

    public string FName
    {
        get { return _Fname; }
        set { _Fname = value; }
    }

    private string _Lname;

    public string LName
    {
        get { return _Lname; }
        set { _Lname = value; }
    }

    private string _email;

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    private string _password;

    public string Password
    {
        set { _password = value; }
    }

    public string GetPassword
    {
        get { return _password; }
    }

    private string _DOB;

    public string DOB
    {
        get { return _DOB; }
        set { _DOB = value; }
    }

    private string _gen;

    public string Gen
    {
        get
        {
            if (_gen != string.Empty)
            {
                if (_gen == "Male")
                {
                    return "M";
                }
                else
                {
                    return "F";
                }
            }
            else
            {
                return null;
            }
        }
        set { _gen = value; }
    }

    public string GetGen
    {
        get
        {
            return _gen;
        }
    }

    string about;

    public string About
    {
        get { return about; }
        set { about = value; }
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

    int abuses;

    public int Abuses
    {
        get { return abuses; }
        set { abuses = value; }
    }

    private string online_name;

    public string Online_name
    {
        get { return online_name; }
        set { online_name = value; }
    }
    #endregion

    public bool RegUser()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("user_Personal_AUD"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "REG";
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = GetPassword;
                cmd.Parameters.Add("@image", SqlDbType.VarChar).Value = Image;
                cmd.Parameters.Add("@s_image", SqlDbType.VarChar).Value = SImage;
                cmd.Parameters.Add("@abuses", SqlDbType.Int).Value = abuses;

                DataTable dTable = doAddUpdateDelete(cmd, true);
                if (dTable.Rows.Count > 0)
                {
                    UserId = Convert.ToInt64(dTable.Rows[0]["USER_ID"]);
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

    public bool EditUser()
    {
        try
        {
            if (UserId != 0)
            {
                using (SqlCommand cmd = new SqlCommand("user_Personal_AUD"))
                {
                    cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "AVATAR";
                    cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = UserId;
                    cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = FName;
                    cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = LName;
                    cmd.Parameters.Add("@dob", SqlDbType.Date).Value = DOB;
                    cmd.Parameters.Add("@gender", SqlDbType.Char).Value = Gen;
                    cmd.Parameters.Add("@about", SqlDbType.VarChar).Value = About;
                    cmd.Parameters.Add("@image", SqlDbType.VarChar).Value = Image;
                    cmd.Parameters.Add("@s_image", SqlDbType.VarChar).Value = SImage;

                    int rows = doAddUpdateDelete(cmd);
                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
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

    public bool DeleteUser()
    {
        try
        {
            if (UserId != 0)
            {
                using (SqlCommand cmd = new SqlCommand("user_Personal_AUD"))
                {
                    cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "DELETE";
                    cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = UserId;

                    int rows = doAddUpdateDelete(cmd);
                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
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

    public bool ReportAbuseUser()
    {
        try
        {
            if (UserId != 0)
            {
                using (SqlCommand cmd = new SqlCommand("user_Personal_AUD"))
                {
                    cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "REPORTABUSE";
                    cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = UserId;

                    int rows = doAddUpdateDelete(cmd);
                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
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

    public bool GetUserById()
    {
        try
        {
            if (UserId != 0)
            {
                using (SqlCommand cmd = new SqlCommand("user_Personal_Get"))
                {
                    cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "GETBYID";
                    cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = UserId;
                    DataTable dTable = getData(cmd);
                    if (dTable.Rows.Count > 0)
                    {
                        UserId = Convert.ToInt32(dTable.Rows[0]["user_id"]);
                        FName = dTable.Rows[0]["fname"].ToString();
                        LName = dTable.Rows[0]["lname"].ToString();
                        Email = dTable.Rows[0]["email"].ToString();
                        if (!string.IsNullOrEmpty(dTable.Rows[0]["dob"].ToString()))
                        {
                            DOB = Convert.ToDateTime(dTable.Rows[0]["dob"]).ToString("dd/MM/yyyy");
                        }
                        Gen = dTable.Rows[0]["gender"].ToString();
                        About = dTable.Rows[0]["about"].ToString();
                        Image = dTable.Rows[0]["image"].ToString();
                        SImage = dTable.Rows[0]["s_image"].ToString();
                        Abuses = Convert.ToInt32(dTable.Rows[0]["abuses"].ToString());
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
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

    public bool CheckUser()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("user_Personal_Get"))
            {
                cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "CHECKUSER";
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
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

    public DataTable GetAllUser()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("user_Personal_Get"))
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

    public bool GetChatUser()
    {
        try
        {
            if (UserId != 0)
            {
                using (SqlCommand cmd = new SqlCommand("getLoggedInUser"))
                {
                    cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "USER";
                    cmd.Parameters.Add("@u_id", SqlDbType.BigInt).Value = UserId;
                    DataTable dTable = getData(cmd);
                    if (dTable.Rows.Count > 0)
                    {
                        UserId = Convert.ToInt32(dTable.Rows[0]["user_id"]);
                        Online_name = dTable.Rows[0]["online_name"].ToString();
                        Image = dTable.Rows[0]["image"].ToString();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
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
}