using System;
using System.Configuration;
using System.Data.SqlClient;

public class DB
{
    private SqlConnection c_connection;
	public DB()
	{
        c_connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteConnString"].ConnectionString.ToString());
	}

    public void openConn()
    {
        if (c_connection.State != System.Data.ConnectionState.Open)
        {
            c_connection.Open();
        }
    }

    public void closeConn()
    {
        if (c_connection.State == System.Data.ConnectionState.Open)
        {
            c_connection.Close();
        }
    }

    public int Query(String p_stored_proc)
    {
        int f_result = 0;
        SqlCommand f_command = new SqlCommand(p_stored_proc, c_connection);
        f_command.CommandType = System.Data.CommandType.StoredProcedure;        
        
        try
        {
            openConn();
            f_result = f_command.ExecuteNonQuery();
            c_connection.Close();            
        }
        catch (Exception ex)
        {
            f_result = -2;
            throw (ex);
        }

        return f_result;
    }

    public int Query(String p_stored_proc, SqlParameter[] p_param)
    {
        int f_result = 0;
        SqlCommand Command = new SqlCommand(p_stored_proc, c_connection);
        Command.CommandType = System.Data.CommandType.StoredProcedure;        

        try
        {
            if (p_param != null)
            {
                int Count = 0;
                for (Count = p_param.GetLowerBound(0); Count <= p_param.GetUpperBound(0); Count++)
                {
                    Command.Parameters.Add(p_param[Count]);
                }
            }

            openConn();
            f_result = Command.ExecuteNonQuery();
            c_connection.Close();
        }
        catch (Exception ex)
        {
            f_result = -2;
            throw (ex);
        }
        return f_result;
    }

    public SqlDataReader GetRows(String p_stored_proc)
    {
        SqlDataReader f_reader;
        SqlCommand Command = new SqlCommand(p_stored_proc, c_connection);
        Command.CommandType = System.Data.CommandType.StoredProcedure;

        try
        {
            openConn();
            f_reader = Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
            f_reader = null;
            throw (ex);
        }
        return f_reader;
    }

    public SqlDataReader GetRows(String p_stored_proc, SqlParameter[] p_param)
    {
        SqlDataReader f_reader;
        SqlCommand Command = new SqlCommand(p_stored_proc, c_connection);
        Command.CommandType = System.Data.CommandType.StoredProcedure;

        try
        {
            if (p_param != null)
            {
                int Count = 0;
                for (Count = p_param.GetLowerBound(0); Count <= p_param.GetUpperBound(0); Count++)
                {
                    Command.Parameters.Add(p_param[Count]);
                }
            }

            openConn();
            f_reader = Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
            f_reader = null;
            throw (ex);
        }
        return f_reader;
    }
}
