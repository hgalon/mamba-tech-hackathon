using System;
using System.Text;

namespace HackathonTotvs.Service.Utils
{
    public static class Utilities
    {
        public static string CalculateSHA1(string text)
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                System.Security.Cryptography.SHA1CryptoServiceProvider cryptoTransformSHA1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
                return hash;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }

        public static string GenerateGuid()
        {
            try
            {
                Guid guid = Guid.NewGuid();
                return guid.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string CalculateMD5(string input)
        {
            StringBuilder hash = new StringBuilder();
            System.Security.Cryptography.MD5CryptoServiceProvider md5provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
