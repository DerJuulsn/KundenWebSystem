using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KundenWebSystem.Database.Model;

namespace KundenWebSystem.Services
{
    public class SignInService
    {
        private static readonly Dictionary<string, int> loggedInUser = new();

        private readonly SessionStorageService storageService;
        private readonly HashTranslatorService hashTranslator;

        public SignInService(SessionStorageService storageService, HashTranslatorService hashTranslator)
        {
            this.storageService = storageService;
            this.hashTranslator = hashTranslator;
        }

        public async Task<int?> GetLoggedInUserId()
        {
            var sessionID = await storageService.GetSessionID();
            
            if (sessionID == null)
                return null;

            if (loggedInUser.TryGetValue(sessionID, out var id))
                return id;

            return null;
        }

        public async Task<bool> TryLogIn(string password, string email)
        {
            var kunde = await hashTranslator.CheckPassword(password, email);

            if (kunde == null) 
                return false;
            
            await LogInUser(kunde);
            
            return true;
        }

        private async Task LogInUser(tbl_Kunden kunde)
        {
            var guid = Guid.NewGuid().ToString();
            loggedInUser.Add(guid, kunde.kd_KundenID);
            await storageService.SetSessionID(guid);
        }
    }
}