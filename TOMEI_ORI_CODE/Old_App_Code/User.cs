using System;
using System.Data.SqlClient;

public class UserSet
{
    private String c_userid;
    private String c_username;
    private String c_password;
    private String c_role;
    private String c_encrypted_password;

    public String UserID
    {
        get 
        {
            return c_userid;
        }
        set
        {
            c_userid = value;
        }
    }

    public String UserName
    {
        get
        {
            return c_username;
        }
        set
        {
            c_username = value;
        }
    }
    
    public String Password
    {
        get
        {
            return c_password;
        }
        set
        {
            c_password = value;
        }
    }

    public String Role
    {
        get
        {
            return c_role;
        }
        set
        {
            c_role = value;
        }
    }

    public String Encrypted_Password
    {
        get
        {
            return c_encrypted_password;
        }
        set
        {
            c_encrypted_password = value;
        }
    }

    public UserSet(String p_userid, String p_password)
    {
        c_userid = p_userid;
        c_password = p_password;
        c_encrypted_password = Tool.encrypt(p_password.ToLower());
    }

    public bool Login()
    {
        bool f_result = false;
        if ((validateUserAccess() == true) && (UpdateLoginDatetime() == true))
        {
            f_result = true;
        }
        return f_result;
    }

    private bool validateUserAccess()
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[2];
        f_Param[0] = new SqlParameter("@UserID", System.Data.SqlDbType.VarChar, 32);
        f_Param[0].Value = c_userid;
        f_Param[1] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar, 50);
        f_Param[1].Value = c_encrypted_password;
        SqlDataReader Reader = f_DBEngine.GetRows("S_Login", f_Param);
        if (Reader.HasRows == true)
        {
            Reader.Read();
            c_username = Reader["UserName"].ToString();
            c_role = Reader["UserRole"].ToString();
            f_result = true;
        }
        else
        {
            f_result = false;
        }
        Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;
        return f_result;
    }

    private bool UpdateLoginDatetime()
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] Param = new SqlParameter[1];
        Param[0] = new SqlParameter("@UserID", System.Data.SqlDbType.VarChar, 32);
        Param[0].Value = c_userid;
        if (f_DBEngine.Query("S_UpdateLoginDatetime", Param) == 1)
        {
            f_result = true;
        }
        else
        {
            f_result = false;
        }
        f_DBEngine.closeConn();
        f_DBEngine = null;
        return f_result;
    }

    public static int getRole(String UserID)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@UserID", System.Data.SqlDbType.VarChar, 32);
        f_Param[0].Value = UserID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetRole", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["UserRole"].ToString());
        }
        else
        {
            f_result = 0;
        }
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;
        return f_result;
    }

    public static int getStatus(String UserID)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@UserID", System.Data.SqlDbType.VarChar, 32);
        f_Param[0].Value = UserID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetStatus", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["Status"].ToString());
        }
        else
        {
            f_result = 0;
        }
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;
        return f_result;
    }

    public static bool checkExist(String UserID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@UserID", System.Data.SqlDbType.VarChar, 32);
        f_Param[0].Value = UserID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckUserExist", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["UserID"].ToString() != String.Empty)
            {
                f_result = true;
            }
        }
        else
        {
            f_result = false;
        }
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;
        return f_result;
    }

    public static bool activatesuspend(String UserID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@UserID", System.Data.SqlDbType.VarChar, 32);
        f_Param[0].Value = UserID;
        if (f_DBEngine.Query("S_UpdateStatus", f_Param) == 1)
        {
            f_result = true;
        }
        else
        {
            f_result = false;
        }
        f_DBEngine.closeConn();
        f_DBEngine = null;
        return f_result;
    }
}
