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
        private readonly KWSContext db;

        public SignInService(SessionStorageService storageService, KWSContext db)
        {
            this.storageService = storageService;
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

        // public bool TryLogIn(LogInModel model)
        // {
        //     // TODO
        //     //db.tbl_Kunden.Where(kunden => kunden.)
        //     
        //     // LogInUser()
        //
        //     return false;
        // }

        private async Task LogInUser(tbl_Kunden kunde)
        {
            var guid = Guid.NewGuid().ToString();
            loggedInUser.Add(guid, kunde.kd_KundenID);
            await storageService.SetSessionID(guid);
        }
    }
}