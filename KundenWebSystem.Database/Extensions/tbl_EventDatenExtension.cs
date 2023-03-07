using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenWebSystem.Database.Model
{
    public partial class tbl_EventDaten
    {

        public int FreeSpots => this.ed_MaxTeilnehmer - this.ed_AktTeilnehmer;

    }
}
