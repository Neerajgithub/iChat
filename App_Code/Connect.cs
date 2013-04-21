public class Connect
{
	public Connect()
	{
		
	}

    private System.Data.SqlClient.SqlConnection _con;
    private System.Data.SqlClient.SqlConnection _conNo;

    protected System.Data.SqlClient.SqlConnection con
    {
        get
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["appCon"].ConnectionString;
            _con = new System.Data.SqlClient.SqlConnection(conString);
            _con.Open();
            return _con;
        }
    }

    protected System.Data.SqlClient.SqlConnection conNo
    {
        get
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["appCon"].ConnectionString;
            _conNo = new System.Data.SqlClient.SqlConnection(conString);
            return _conNo;
        }
    }

    protected void conClose()
    {
        if (_con.State == System.Data.ConnectionState.Open)
        {
            _con.Close();
        }
    }

    protected void conCloseNo()
    {
        if (_conNo.State == System.Data.ConnectionState.Open)
        {
            _conNo.Close();
        }
    }

    protected void conOpen()
    {
        if (_conNo.State != System.Data.ConnectionState.Open)
        {
            _conNo.Open();
        }
    }
}