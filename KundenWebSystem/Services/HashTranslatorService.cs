using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using KundenWebSystem.Data;
using KundenWebSystem.Database.Model;
using Microsoft.EntityFrameworkCore;

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

        public bool CheckPassword(string hashedPassword, string typedPassword)
        {
            try
            {
                // transform and check
                return StringToHash(typedPassword) == hashedPassword;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static string? StringToHash(string? input)
        {
            var md5 = MD5.Create();

            if (input == null)
                return null;

            var passwordInBytes = Encoding.UTF8.GetBytes(input);
            var passwordHashInBytes = md5.ComputeHash(passwordInBytes);

            var sb = new StringBuilder();
            foreach (var t in passwordHashInBytes)
            {
                sb.Append(t.ToString("x2"));
            }

            return sb.ToString();
        }

        public tbl_Kunden GetLastLogin()
        {
            return lastlogin;
        }
    }
}