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
            return await this.databaseContext.tbl_Buchungen.Include(o => o.ed_EvDaten.et_Event).Where(buchung => buchung.kd_KundenID == userId).ToListAsync();
        }

        public async Task<tbl_EventDaten> GetEventDatenFromId(int eventDatenID)
        {
            return await this.databaseContext.tbl_EventDaten
                .Include(o => o.et_Event.ev_EvVeranstalter)
                .Include(o => o.et_Event.ek_EvKategorie)
                .FirstOrDefaultAsync(eventDaten => eventDaten.ed_EvDatenID == eventDatenID);
        }

        public async Task<tbl_Buchungen> GetBuchungFromId(int buchungId)
        {
            return await this.databaseContext.tbl_Buchungen.Include(o => o.ed_EvDaten).Where(buchung => buchung.bu_BuchungsID == buchungId).FirstOrDefaultAsync();
        }
    }

}
