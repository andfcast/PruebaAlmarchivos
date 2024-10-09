using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp.Domain.Utils
{
    public static class Helpers
    {
        public static string Encriptar(string cadena) {
            StringBuilder sb =  new StringBuilder();
            using (SHA256 hash = SHA256.Create()) { 
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(cadena));
                foreach (byte b in result) {
                    sb.Append(b.ToString("x2"));
                }
            }
                return sb.ToString();
        }        
    }
}
