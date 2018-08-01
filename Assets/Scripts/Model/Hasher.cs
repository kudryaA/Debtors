using System;
using System.Security.Cryptography;
using System.Text;

namespace Model
{
    public class Hasher
    {
        public string Hash { get; private set; }

        public Hasher(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);            
            var result = new SHA256Managed().ComputeHash(data);
            Hash =  BitConverter.ToString(result).Replace("-","").ToLower();
        }
        
    }
}