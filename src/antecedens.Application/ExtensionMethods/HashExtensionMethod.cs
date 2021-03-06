using System.Security.Cryptography;
using System.Text;

namespace antecedens.Application.ExtensionMethods
{
    public static class HashExtensionMethod
    {
        public static string Sha256Hash(this string rawData)
        {            
            using (SHA256 sha256Hash = SHA256.Create())
            {                
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
 
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
