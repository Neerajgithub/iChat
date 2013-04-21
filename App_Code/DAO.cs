public class DAO : Connect
{
	public DAO(){}

    protected System.Data.DataTable getData(string sql)
    {
        try
        {
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(sql, conNo);
            System.Data.DataTable dtable = new System.Data.DataTable();
            adapter.Fill(dtable);
            return dtable;
        }
        catch(System.Exception  ex)
        {
            conCloseNo();
            return null;
        }
    }

    protected System.Data.DataTable getData(System.Data.SqlClient.SqlCommand sql)
    {
        try
        {
            sql.Connection = conNo;
            sql.CommandType = System.Data.CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(sql);
            System.Data.DataTable dtable = new System.Data.DataTable();
            adapter.Fill(dtable);
            return dtable;
        }
        catch (System.Exception ex)
        {
            conCloseNo();
            return null;
        }
    }

    protected void FillDDL(ref System.Web.UI.WebControls.DropDownList ddl, string sql, string textField, string valueField)
    {
        try
        {
            ddl.DataSource = getData(sql);
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
        }
        catch (System.Exception ex)
        {
            conCloseNo();
        }
    }

    protected void FillDDL(ref System.Web.UI.WebControls.DropDownList ddl, System.Data.SqlClient.SqlCommand sql, string textField, string valueField)
    {
        try
        {
            ddl.DataSource = getData(sql);
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
        }
        catch (System.Exception ex)
        {
            conCloseNo();
        }
    }

    protected int doAddUpdateDelete(System.Data.SqlClient.SqlCommand sql)
    {
        try
        {
            sql.Connection = con;
            sql.CommandType = System.Data.CommandType.StoredProcedure;
            int i = sql.ExecuteNonQuery();
            conClose();
            return i;
        }
        catch (System.Exception ex)
        {
            conClose();
            return 0;
        }
    }

    protected System.Data.DataTable doAddUpdateDelete(System.Data.SqlClient.SqlCommand sql, bool ReturnDataTable)
    {
        try
        {
            sql.Connection = conNo;
            sql.CommandType = System.Data.CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(sql);
            System.Data.DataTable dtable = new System.Data.DataTable();
            adapter.Fill(dtable);
            return dtable;
        }
        catch (System.Exception ex)
        {
            conCloseNo();
            return null;
        }
    }
}