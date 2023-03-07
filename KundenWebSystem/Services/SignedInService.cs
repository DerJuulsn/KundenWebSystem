using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KundenWebSystem.Database.Model;

namespace KundenWebSystem.Services
{
    public class SignInService
    {
        private static Dictionary<string, int> loggedInUser = new();

        private readonly SessionStorageService storageService;
        private readonly HashTranslatorService hashTranslator;
        private readonly KWSContext db;

        public SignInService(SessionStorageService storageService, HashTranslatorService hashTranslator, KWSContext db)
        {
            this.storageService = storageService;
            this.hashTranslator = hashTranslator;
            this.db = db;
        }

        public async Task<int?> GetLoggedInUser()
        {
            var sessionID = await storageService.GetSessionID();
            
            if (sessionID == null)
                return null;

            if (loggedInUser.TryGetValue(sessionID, out var id))
                return id;

            return null;
        }

        public bool TryLogIn(string password, string email)
        {
            if (hashTranslator.CheckPassword(password, email))
            {
                tbl_Kunden user = hashTranslator.GetLastLogin();

                if (user != null)
                {
                    _ = LogInUser(user);
                    return true;
                }
            }
            return false;
        }

        private async Task LogInUser(tbl_Kunden kunde)
        {
            var guid = Guid.NewGuid().ToString();
            loggedInUser.Add(guid, kunde.kd_KundenID);
            await storageService.SetSessionID(guid);
        }
    }
}