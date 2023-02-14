using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using KundenWebSystem.Database.Model;

namespace KundenWebSystem.Data
{
    public class BookingService
    {
        private KWSContext databaseContext;

        public BookingService(KWSContext context)
        {
            this.databaseContext = context;
        }

        public async Task<List<tbl_Buchungen>> GetBuchungenForUserAsync(int userId)
        {
            return await this.databaseContext.tbl_Buchungen.Where(buchung => buchung.kd_KundenID == userId).ToListAsync();
        }

    }
}
