using KundenWebSystem.Database.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KundenWebSystem.Data.Eventseite
{
    public class EventService
    {
        private KWSContext eventcontext;

        public EventService(KWSContext context)
        {
            this.eventcontext = context;
        }

        public async Task<List<EventsResult>> GetAvailableEventsAsync()
        {
            return await eventcontext.tbl_EventDaten
                .Include(o => o.et_Event.ev_EvVeranstalter)
                .Where(o => o.ed_Freigegeben)
                .Select(o => new EventsResult()
                {
                    EventID = o.et_EventID,
                    EventBezeichnung = o.et_Event.et_Bezeichnung,
                    EventDatenBeginn = o.ed_Beginn,
                    EventDatenPreis = o.ed_Preis,
                    EventDatenStartOrt = o.ed_StartOrt,
                    VeranstalterName = o.et_Event.ev_EvVeranstalter.ev_Firma
                })
                .ToListAsync();
           
        }
    }
}
