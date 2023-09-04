using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Security.Cryptography;
using System.IO;

namespace CapaLogica
{
    public class cUtilitarios
    {
        public String ObtenerMD5(String contraseña)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMD5 = md5.ComputeHash(Encoding.Default.GetBytes(contraseña));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMD5.Length; i++)
                sb.AppendFormat("{0:x2}", dataMD5[i]);
            return sb.ToString();
        }
        public String ObtenerSHA1(String contraseña)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            sha1 = SHA1CryptoServiceProvider.Create();
            byte[] datasha1 = sha1.ComputeHash(
                Encoding.Default.GetBytes(contraseña));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < datasha1.Length; i++)
                sb.AppendFormat("{0:x2}", datasha1[i]);
            return sb.ToString().ToUpper();
        }

        // Métodos compartidos para imagenes
        public byte[] Image2Bytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp,
                FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs,
                System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;
            //
            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }

        public Image Bytes2Image(byte[] bytes)
        {
            if (bytes == null) return null;
            //
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return bm;
        }
    }
}
