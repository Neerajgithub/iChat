using System;
using System.Data;
using System.Data.SqlClient;

public class LoginCls : DAO
{
    public LoginCls()
    {
        
    }

    public LoginCls(string uname, string pwd)
    {
        UName = uname;
        PWord = pwd;
    }

    private string _uName;

    public string UName
    {
        get { return _uName; }
        set { _uName = value; }
    }

    private string _pWord;

    public string PWord
    {
        get { return _pWord; }
        set { _pWord = value; }
    }

    private string _profilePage;

    public string ProfilePage
    {
        get { return _profilePage; }
        set { _profilePage = value; }
    }

    private userInfo uInfo;

    public userInfo UInfo
    {
        get { return uInfo; }
    }

    private AdminInfo aInfo;

    public AdminInfo AInfo
    {
        get { return aInfo; }
    }

    public users CheckLogin(string check)
    {
        try
        {
            if (UName != string.Empty && PWord != string.Empty)
            {
                if (check == "admin")
                {
                    using (SqlCommand cmd = new SqlCommand("CheckLogin"))
                    {
                        cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "CHECKADMIN";
                        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = UName;
                        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = PWord;
                        DataTable dTable = getData(cmd);
                        if (dTable.Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(dTable.Rows[0]["IS_USER"]))
                            {
                                aInfo = new AdminInfo();
                                aInfo.UserName = dTable.Rows[0]["user_name"].ToString();
                                ProfilePage = "~/admin/home.aspx";
                                return users.Admin;
                            }
                            else
                            {
                                return users.Anonymous;
                            }
                        }
                        else
                        {
                            return users.Anonymous;
                        }
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("CheckLogin"))
                    {
                        cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "CHECKUSER";
                        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = UName;
                        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = PWord;
                        cmd.Parameters.Add("@online", SqlDbType.VarChar).Value = PWord;
                        DataTable dTable = getData(cmd);
                        if (dTable.Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(dTable.Rows[0]["IS_USER"]))
                            {
                                uInfo = new userInfo();
                                uInfo.UserId = Convert.ToInt64(dTable.Rows[0]["user_id"]);
                                string fName = dTable.Rows[0]["fname"].ToString();
                                string lName = dTable.Rows[0]["lname"].ToString();
                                uInfo.Email = dTable.Rows[0]["email"].ToString();
                                //if (fName == string.Empty)
                                //{
                                //    uInfo.UserName = string.Format("{0} {1}", fName, lName);
                                //}
                                //else
                                //{
                                //    uInfo.UserName = uInfo.UserName;
                                //}
                                uInfo.UserName = getUserName(fName, lName, uInfo.Email);
                                uInfo.About = dTable.Rows[0]["about"].ToString();
                                ProfilePage = "~/home.aspx";
                                return users.User;
                            }
                            else
                            {
                                return users.Anonymous;
                            }
                        }
                        else
                        {
                            return users.Anonymous;
                        }
                    }
                }
            }
            else
            {
                return users.Anonymous;
            }
        }
        catch (Exception ex)
        {
            return users.Anonymous;
        }
    }

    public string getUserName(string fname, string lname, string email)
    {
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

    public void LogOut(long user_id)
    {
        using (SqlCommand cmd = new SqlCommand("CheckLogin"))
        {
            cmd.Parameters.Add("@para", SqlDbType.VarChar).Value = "LOGOUT";
            cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = user_id;
            doAddUpdateDelete(cmd);
        }
    }
}