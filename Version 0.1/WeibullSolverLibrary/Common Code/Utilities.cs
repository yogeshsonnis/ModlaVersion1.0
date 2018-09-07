using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WeibullSolverLibrary.Common_Code
{
   public class Utilities
    {
        public static void EncryptandSave(Model Proj) //To be changed at a later date to entire model
        {
            var json = new JavaScriptSerializer().Serialize(Proj);
            //System.IO.File.WriteAllText(@"F:\WeibullSolver\ModelNoComp.txt", json);
            FileStream stream = new FileStream(@"F:\WeibullSolver\Model.modla",
            FileMode.OpenOrCreate, FileAccess.Write);

            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

            cryptic.Key = ASCIIEncoding.ASCII.GetBytes("CHUCK123");
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes("45NORRIS");

            CryptoStream crStream = new CryptoStream(stream, cryptic.CreateEncryptor(), CryptoStreamMode.Write);
            //GZipStream zipStream = new GZipStream(crStream, CompressionMode.Compress, false);

            byte[] data = ASCIIEncoding.ASCII.GetBytes(json);

            crStream.Write(data, 0, data.Length);

            crStream.Close();
            stream.Close();

        }
        public static Model LoadAndDecrypt()
        {
            FileStream stream = new FileStream(@"F:\WeibullSolver\Model.modla",
                              FileMode.Open, FileAccess.Read);

            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

            cryptic.Key = ASCIIEncoding.ASCII.GetBytes("CHUCK123");
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes("45NORRIS");

            CryptoStream crStream = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read);
            //var chinga = new MemoryStream();
            //GZipStream zipStream = new GZipStream(chinga, CompressionMode.Decompress, false);
            StreamReader reader = new StreamReader(crStream);

            string data = reader.ReadToEnd();

            reader.Close();
            stream.Close();

            var deserialisedobj = new JavaScriptSerializer();
            Model mod = deserialisedobj.Deserialize<Model>(data);
            // Return the encrypted data as a string
            return mod;
        }
        public static double?[] AddArrays(double?[] Array1, double?[] Array2)
        {
            if (Array1 == null) return Array2;
            for (int i = 0; i < Array1.Length; i++)
            {
                Array1[i] = (Array1[i] ?? 0) + (Array2[i] ?? 0);
            }
            return Array1;
        }
    }
}
