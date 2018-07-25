using System;
using System.Collections.Generic;
using System.Web;
using System.Security.Cryptography;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public class Tool
{
    public static String encrypt(String p_string)
    {
        String f_result = "";
        MD5CryptoServiceProvider f_md5 = new MD5CryptoServiceProvider();
        byte[] f_data = System.Text.ASCIIEncoding.Default.GetBytes(p_string);
        f_data = f_md5.ComputeHash(f_data);
        foreach (byte b in f_data)
        {
            f_result += b.ToString("x2");
        }
        return f_result;
    }

    public static Bitmap toBitmap(byte[] data)
    {
        ImageConverter ic = new ImageConverter();
        Image img = (Image)ic.ConvertFrom(data);
        Bitmap b = new Bitmap(img);
        return b;
    }

    public static byte[] toByte(Bitmap b)
    {
        byte[] data;
        using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
        {
            b.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            stream.Position = 0;
            data = new byte[stream.Length];
            stream.Read(data, 0, int.Parse(stream.Length.ToString()));
            stream.Close();
        }
        return data;
    }

    public static Bitmap ResizeBitmap(Bitmap b)
    {
        int nWidth = 300;
        int nHeight = 300;
        float oldWidth = b.Width;
        float oldHeight = b.Height;
        float ratio = (oldHeight / 300 > oldWidth / 300 ? oldHeight / 300 : oldWidth / 300);
        if (oldHeight / 300 > oldHeight / 300)
        {
            nWidth = (int)(b.Width / ratio);
            nHeight = 300;
        }
        else
        {
            nWidth = 300;
            nHeight = (int)(b.Height / ratio);
        }
        Bitmap result = new Bitmap(nWidth, nHeight);
        using (Graphics g = Graphics.FromImage((Image)result))
            g.DrawImage(b, 0, 0, nWidth, nHeight);
        return result;
    }

    public static Bitmap rotateImage(Bitmap b)
    {
        Bitmap r = b;
        r.RotateFlip(RotateFlipType.Rotate90FlipNone);
        return r;
    }

    public static bool IsNumeric(object Expression)
    {
        // Variable to collect the Return value of the TryParse method.
        bool isNum;

        // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
        double retNum;

        // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
        // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
        isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        return isNum;
    }	
    //public static Bitmap Ori
}
