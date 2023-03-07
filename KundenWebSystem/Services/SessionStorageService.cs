using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace KundenWebSystem.Services
{
    public class SessionStorageService
    {
        private readonly ProtectedLocalStorage storage;

        private const string Key = "sessionID"; 

        public SessionStorageService(ProtectedLocalStorage storage)
        {
            this.storage = storage;
        }
        
        public async Task SetSessionID(string sessionID) => await storage.SetAsync(Key, sessionID);
        
        public async Task<string?> GetSessionID()
        {
            var result = await storage.GetAsync<string?>(Key);

            return !result.Success ? null : result.Value;
        }
        
        public async Task ClearSessionID() => await storage.DeleteAsync(Key);
    }
}