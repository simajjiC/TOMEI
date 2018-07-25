using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data.SqlClient;

public class Product
{
    public static int getProductCategoryID(String CategoryCode)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@SeriesID", System.Data.SqlDbType.VarChar, 32);
        f_Param[0].Value = CategoryCode;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetProductCategory", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["ProductCategory"].ToString());
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

    public static int getProductSubCategoryID(String SubCategoryCode)
    {
        int f_result = 0;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@SeriesID", System.Data.SqlDbType.VarChar, 32);
        f_Param[0].Value = SubCategoryCode;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetProductSubCategory", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            f_result = int.Parse(f_Reader["ProductSubCategory"].ToString());
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

    public static bool checkProductExist(String ProductNo)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@ProductNo", System.Data.SqlDbType.VarChar, 32);
        f_Param[0].Value = ProductNo;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckProductNo", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["recordcount"].ToString() == "0")
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

    public static bool checkBarcodeFlag(int ID)
    {
        bool f_result = true;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@id", System.Data.SqlDbType.VarChar, 32);
        f_Param[0].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckBarcodeFlag", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["BarcodeFlag"].ToString() == "1")
            {
                f_result = true;
            }
            else
            {
                f_result = false;
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

    public static bool checkProductCategoryExist(String CategoryCode, int ID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[2];
        f_Param[0] = new SqlParameter("@CategoryCode", System.Data.SqlDbType.VarChar, 32);
        f_Param[0].Value = CategoryCode;
        f_Param[1] = new SqlParameter("@ID", System.Data.SqlDbType.Int);
        f_Param[1].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckCategoryCode", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["recordcount"].ToString() == "0")
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

    public static bool checkProductBarcodeWithProductGroupCodeExist(String ProductGroupCode)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[1];
        f_Param[0] = new SqlParameter("@ProductGroupCode", System.Data.SqlDbType.VarChar, 32);
        f_Param[0].Value = ProductGroupCode;
        
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckProductBarcodeWithProductGroupCode", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["recordcount"].ToString() == "0")
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

    public static bool checkProductGroupExist(String ProductGroupCode, int ID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[2];
        f_Param[0] = new SqlParameter("@ProductGroupCode", System.Data.SqlDbType.VarChar, 32);
        f_Param[0].Value = ProductGroupCode;
        f_Param[1] = new SqlParameter("@ID", System.Data.SqlDbType.Int);
        f_Param[1].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckProductGroupCode", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["recordcount"].ToString() == "0")
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

    public static bool checkProductSubCategoryExist(String SubCategoryCode, int ID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[2];
        f_Param[0] = new SqlParameter("@SubCategoryCode", System.Data.SqlDbType.VarChar, 64);
        f_Param[0].Value = SubCategoryCode;
        f_Param[1] = new SqlParameter("@ID", System.Data.SqlDbType.VarChar, 64);
        f_Param[1].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckSubCategoryCode", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["recordcount"].ToString() == "0")
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

    public static bool checkProductSeriesExist(int CategoryCode, int SubCategoryCode, int ID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[3];
        f_Param[0] = new SqlParameter("@CategoryCode", System.Data.SqlDbType.Int);
        f_Param[0].Value = CategoryCode;
        f_Param[1] = new SqlParameter("@SubCategoryCode", System.Data.SqlDbType.Int);
        f_Param[1].Value = SubCategoryCode;
        f_Param[2] = new SqlParameter("@ID", System.Data.SqlDbType.Int);
        f_Param[2].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckSeries", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["recordcount"].ToString() == "0")
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

    public static bool checkProductSeriesPrefixExist(String Prefix, int ID)
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[2];
        f_Param[0] = new SqlParameter("@SeriesPrefix", System.Data.SqlDbType.VarChar, 16);
        f_Param[0].Value = Prefix;
        f_Param[1] = new SqlParameter("@ID", System.Data.SqlDbType.Int);
        f_Param[1].Value = ID;
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_CheckSeriesPrefix", f_Param);
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();
            if (f_Reader["recordcount"].ToString() == "0")
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

}
