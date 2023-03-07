using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KundenWebSystem.Data.Eventseite
{
    public class EventsResult
    {
        public int EventID { get; set; }
        public string EventDatenStartOrt { get; set; }
        public DateTime EventDatenBeginn { get; set; }
        public decimal EventDatenPreis { get; set; }
        public string VeranstalterName { get; set; }
        public string EventBezeichnung { get; set; }
    }
}
