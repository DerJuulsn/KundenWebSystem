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

        public async Task<List<BookingDataSet>> GetBuchungenForUserAsync(int userId)
        {
            List<BookingDataSet> list = new List<BookingDataSet>();
            await this.databaseContext.tbl_Buchungen.Where(buchung => buchung.kd_KundenID == userId).ForEachAsync(async buchung =>
            {
                tbl_EventDaten evDaten = await GetEventDatenFromId(buchung.ed_EvDatenID);
                tbl_Events events = await GetEventFromId(evDaten.et_EventID);

                list.Add(new BookingDataSet()
                {
                    BuchungData = buchung,
                    EventDatenData = evDaten,
                    EventsData = events
                });
            });
            return list;
        }

        public async Task<tbl_EventDaten> GetEventDatenFromId(int eventDatenID)
        {
            return await this.databaseContext.tbl_EventDaten.Where(eventDaten => eventDaten.ed_EvDatenID == eventDatenID).FirstAsync();
        }

        public async Task<tbl_Events> GetEventFromId(int eventId)
        {
            return await this.databaseContext.tbl_Events.Where(events => events.et_EventID == eventId).FirstAsync();
        }

        public struct BookingDataSet
        {
            public tbl_Buchungen BuchungData { get; set; }
            public tbl_EventDaten EventDatenData { get; set; }
            public tbl_Events EventsData { get; set; }


        }

    }
}
