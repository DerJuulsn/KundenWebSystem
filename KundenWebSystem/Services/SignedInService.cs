using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KundenWebSystem.Data;
using KundenWebSystem.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace KundenWebSystem.Services
{
    public class SignInService
    {
        public event EventHandler? Changed;
        
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

        public async Task<bool> TryLogIn(LoginModel model)
        {
            var user = await db.tbl_Kunden.FirstOrDefaultAsync(k => k.kd_EMail == model.Email);

            if (user?.kd_PasswortHash == null)
                return false;

            if (!hashTranslator.CheckPassword(user.kd_PasswortHash, model.Password)) 
                return false;
            
            await LogInUser(user);
            Changed?.Invoke(this, EventArgs.Empty);
            
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