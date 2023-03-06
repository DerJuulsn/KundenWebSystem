using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using KundenWebSystem.Database.Model;

namespace KundenWebSystem.Database.Model
{
    public class HashTranslator
    {
        public bool CheckPassword(string password, string email, KWSContext context)
        {
            try
            {
                //Get hash from the database
                string? storedPasswordHash = context.tbl_Kunden.Where(k => k.kd_EMail == email).First().kd_PasswortHash;

                //transform password into hash
                string? passwordHash = StringToHash(password);

                //compare the hashes
                if (passwordHash.Equals(storedPasswordHash))
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string? StringToHash(string? input)
        {
            MD5 md5 = MD5.Create() ;
            byte[] passwordInBytes = Encoding.UTF8.GetBytes(input);
            byte[] passwordHashInBytes = md5.ComputeHash(passwordInBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < passwordHashInBytes.Length; i++)
            {
                sb.Append(passwordHashInBytes[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
