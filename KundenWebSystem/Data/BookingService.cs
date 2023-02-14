﻿using System;
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
            return await this.databaseContext.tbl_Buchungen.Include(o => o.ed_EvDaten).Include(o => o.ed_EvDaten.et_Event).Where(buchung => buchung.kd_KundenID == userId).ToListAsync();
        }

        public async Task<tbl_EventDaten> GetEventDatenFromId(int eventDatenID)
        {
            return await this.databaseContext.tbl_EventDaten.Where(eventDaten => eventDaten.ed_EvDatenID == eventDatenID).FirstAsync();
        }

        public async Task<tbl_Events> GetEventFromId(int eventId)
        {
            return await this.databaseContext.tbl_Events.Where(events => events.et_EventID == eventId).FirstAsync();
        }
    }
}
