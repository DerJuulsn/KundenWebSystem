using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using KundenWebSystem.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KundenWebSystem.Services
{
    public class HashTranslatorService
    {
        private readonly KWSContext context;

        public HashTranslatorService(KWSContext context) => this.context = context;

        public async Task<tbl_Kunden?> CheckPassword(string password, string email)
        {
            try
            {
                //Get hash from the database
                var kunde = await context.tbl_Kunden.Where(k => k.kd_EMail == email).FirstOrDefaultAsync();

                if (kunde is not {kd_PasswortHash: not null})
                    return null;

                var storedPasswordHash = kunde.kd_PasswortHash!;

                //transform password into hash
                var passwordHash = StringToHash(password);

                //compare the hashes
                return passwordHash.Equals(storedPasswordHash) ? kunde : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        private static string StringToHash(string input)
        {
            var md5 = MD5.Create();

            var passwordInBytes = Encoding.UTF8.GetBytes(input);
            var passwordHashInBytes = md5.ComputeHash(passwordInBytes);

            var sb = new StringBuilder();
            foreach (var t in passwordHashInBytes) 
                sb.Append(t.ToString("x2"));

            return sb.ToString();
        }
    }
}