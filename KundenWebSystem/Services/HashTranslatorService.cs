using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using KundenWebSystem.Database.Model;

namespace KundenWebSystem.Services
{
    public class HashTranslatorService
    {
        private readonly KWSContext context;
        private tbl_Kunden? lastlogin;

        public HashTranslatorService(KWSContext context)
        {
            this.context = context;
        }

        public bool CheckPassword(string password, string email)
        {
            try
            {
                //Get hash from the database
                lastlogin = context.tbl_Kunden.Where(k => k.kd_EMail == email).First();
                string? storedPasswordHash = lastlogin.kd_PasswortHash;

                //transform password into hash
                string? passwordHash = StringToHash(password);

                if (passwordHash == null)
                    return false;

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

            if (input == null)
                return null;

            byte[] passwordInBytes = Encoding.UTF8.GetBytes(input);
            byte[] passwordHashInBytes = md5.ComputeHash(passwordInBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < passwordHashInBytes.Length; i++)
            {
                sb.Append(passwordHashInBytes[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public tbl_Kunden GetLastLogin()
        {
            return lastlogin;
        }
    }
}
