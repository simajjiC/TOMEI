using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Stone
/// </summary>
public class Stone
{
	public static bool checkExist(String StoneID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@StoneID", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = StoneID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckStoneExist", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["StoneCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static bool checkClarity(String Clarity)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@Clarity", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Clarity;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckClarity", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["ClarityCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static bool checkColour(String Colour)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@Colour", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Colour;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckColour", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["ColourCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static bool checkFluorescence(String Fluorescence)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@Fluorescence", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Fluorescence;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckFluorescence", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["FluorescenceCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static bool checkGirdle(String Girdle)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@Girdle", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Girdle;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckGirdle", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["GirdleCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static bool checkPolish(String Polish)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@Polish", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Polish;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckPolish", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["PolishCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static bool checkSymmetry(String Symmetry)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@Symmetry", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Symmetry;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckSymmetry", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["SymmetryCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static int getClarity(String Clarity)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@Clarity", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Clarity;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetClarity", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();            
            f_result = int.Parse(f_Reader["id"].ToString());
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

    public static int getColour(String Colour)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@Colour", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Colour;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetColour", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["id"].ToString());
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

    public static int getFluorescence(String Fluorescence)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@Fluorescence", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Fluorescence;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetFluorescence", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["id"].ToString());
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

    public static int getGirdle(String Girdle)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@Girdle", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Girdle;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetGirdle", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["id"].ToString());
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

    public static int getPolish(String Polish)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@Polish", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Polish;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetPolish", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["id"].ToString());
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

    public static int getSymmetry(String Symmetry)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@Symmetry", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Symmetry;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetSymmetry", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["id"].ToString());
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

    public static bool insertStone(String StoneID, String Weight, int Clarity, int Colour, int Fluorescence, int Girdle, int Polish, int Symmetry, float Depth, float Size, float Measurement1, float Measurement2, float Measurement3, String UserID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[14];
        f_Param[0] = new SqlParameter("@StoneID", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = StoneID;
        f_Param[1] = new SqlParameter("@Weight", System.Data.SqlDbType.VarChar, 50);
        f_Param[1].Value = String.Format(Weight.ToString(), "{0:0.0}");
        f_Param[2] = new SqlParameter("@Clarity", System.Data.SqlDbType.TinyInt);
        f_Param[2].Value = Clarity;
        f_Param[3] = new SqlParameter("@Colour", System.Data.SqlDbType.TinyInt);
        f_Param[3].Value = Colour;
        f_Param[4] = new SqlParameter("@Fluorescence", System.Data.SqlDbType.TinyInt);
        f_Param[4].Value = Fluorescence;
        f_Param[5] = new SqlParameter("@Girdle", System.Data.SqlDbType.TinyInt);
        f_Param[5].Value = Girdle;
        f_Param[6] = new SqlParameter("@Polish", System.Data.SqlDbType.TinyInt);
        f_Param[6].Value = Polish;
        f_Param[7] = new SqlParameter("@Symmetry", System.Data.SqlDbType.TinyInt);
        f_Param[7].Value = Symmetry;
        f_Param[8] = new SqlParameter("@Depth", System.Data.SqlDbType.Float);
        f_Param[8].Value = String.Format(Depth.ToString(),"{0:0.0}");
        f_Param[9] = new SqlParameter("@Size", System.Data.SqlDbType.Float);
        f_Param[9].Value = String.Format(Size.ToString(),"{0:0.0}");
        f_Param[10] = new SqlParameter("@Measurement1", System.Data.SqlDbType.Float);
        f_Param[10].Value = String.Format(Measurement1.ToString(),"{0:0.0}");
        f_Param[11] = new SqlParameter("@Measurement2", System.Data.SqlDbType.Float);
        f_Param[11].Value = String.Format(Measurement2.ToString(),"{0:0.0}");
        f_Param[12] = new SqlParameter("@Measurement3", System.Data.SqlDbType.Float);
        f_Param[12].Value = String.Format(Measurement3.ToString(),"{0:0.0}");
        f_Param[13] = new SqlParameter("@CreatedBy", System.Data.SqlDbType.VarChar, 32);
        f_Param[13].Value = UserID;
        int f_RowInserted = f_DBEngine.Query("S_InsertStone", f_Param);
        if (f_RowInserted == 1)
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

    public static string CreateCertificate(String ProductNo, int ProductSeries, String UserID)
    {
        string f_result = "";
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[3];
        f_Param[0] = new SqlParameter("@ProductNo", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = ProductNo;
        f_Param[1] = new SqlParameter("@ProductSeries", System.Data.SqlDbType.Int);
        f_Param[1].Value = ProductSeries;
        f_Param[2] = new SqlParameter("@CreatedBy", System.Data.SqlDbType.VarChar, 32);
        f_Param[2].Value = UserID;
        SqlDataReader new_id = f_DBEngine.GetRows("S_InsertCertificate", f_Param);
        if (new_id.HasRows)
        {
            new_id.Read();
            f_result = new_id["new_id"].ToString();
        }
        else
        {
            f_result = "";
        }
        f_DBEngine.closeConn();
        f_DBEngine = null;
        return f_result;
    }

    public static bool UpdateStoneCertificate(String GUID, int CertificateNo, String UserID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[3];
        f_Param[0] = new SqlParameter("@GUID", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = GUID;
        f_Param[1] = new SqlParameter("@CertificateNo", System.Data.SqlDbType.Int);
        f_Param[1].Value = CertificateNo;
        f_Param[2] = new SqlParameter("@UpdatedBy", System.Data.SqlDbType.VarChar, 32);
        f_Param[2].Value = UserID;
        int f_RowInserted = f_DBEngine.Query("S_UpdateStoneCertificate", f_Param);
        if (f_RowInserted == 1)
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

    public static bool InsertUploadAction(int uploaded, int success, int failed, string UserID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[4];
        f_Param[0] = new SqlParameter("@Uploaded", System.Data.SqlDbType.Int);
        f_Param[0].Value = uploaded;
        f_Param[1] = new SqlParameter("@Success", System.Data.SqlDbType.Int);
        f_Param[1].Value = success;
        f_Param[2] = new SqlParameter("@Failed", System.Data.SqlDbType.Int);
        f_Param[2].Value = failed;
        f_Param[3] = new SqlParameter("@UserID", System.Data.SqlDbType.VarChar, 32);
        f_Param[3].Value = UserID;
        int f_RowInserted = f_DBEngine.Query("S_InsertUploadAction", f_Param);
        if (f_RowInserted == 1)
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

    public static bool checkClarityExist(String Clarity, int ID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[2];
        f_Param[0] = new SqlParameter("@Clarity", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Clarity;
        f_Param[1] = new SqlParameter("@ID", System.Data.SqlDbType.Int);
        f_Param[1].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckClarityExist", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["ClarityCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static bool checkColourExist(String Colour, int ID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[2];
        f_Param[0] = new SqlParameter("@Colour", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Colour;
        f_Param[1] = new SqlParameter("@ID", System.Data.SqlDbType.Int);
        f_Param[1].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckColourExist", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["ColourCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static bool checkFluorescenceExist(String Fluorescence, int ID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[2];
        f_Param[0] = new SqlParameter("@Fluorescence", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Fluorescence;
        f_Param[1] = new SqlParameter("@ID", System.Data.SqlDbType.Int);
        f_Param[1].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckFluorescenceExist", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["FluorescenceCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static bool checkGirdleExist(String Girdle, int ID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[2];
        f_Param[0] = new SqlParameter("@Girdle", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Girdle;
        f_Param[1] = new SqlParameter("@ID", System.Data.SqlDbType.Int);
        f_Param[1].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckGirdleExist", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["GirdleCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static bool checkPolishExist(String Polish, int ID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[2];
        f_Param[0] = new SqlParameter("@Polish", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Polish;
        f_Param[1] = new SqlParameter("@ID", System.Data.SqlDbType.Int);
        f_Param[1].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckPolishExist", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["PolishCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static bool checkSymmetryExist(String Symmetry, int ID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[2];
        f_Param[0] = new SqlParameter("@Symmetry", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = Symmetry;
        f_Param[1] = new SqlParameter("@ID", System.Data.SqlDbType.Int);
        f_Param[1].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckSymmetryExist", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["SymmetryCount"].ToString() == "0")
            {
                f_result = false;
            }
            else
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

    public static int getClarityID(String ID)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@ID", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetClarityID", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["Clarity"].ToString());
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

    public static int getColourID(String ID)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@ID", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetColourID", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["Colour"].ToString());
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

    public static int getFluorescenceID(String ID)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@ID", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetFluorescenceID", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["Fluorescence"].ToString());
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

    public static int getGirdleID(String ID)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@ID", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetGirdleID", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["Girdle"].ToString());
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

    public static int getPolishID(String ID)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@ID", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetPolishID", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["Polish"].ToString());
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

    public static int getSymmetryID(String ID)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@ID", System.Data.SqlDbType.VarChar, 50);
        f_Param[0].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetSymmetryID", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["Symmetry"].ToString());
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
}
