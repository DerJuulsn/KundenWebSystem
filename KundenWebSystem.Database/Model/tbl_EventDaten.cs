using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KundenWebSystem.Database.Model
{
    public partial class tbl_EventDaten
    {
        [Key]
        public int ed_EvDatenID { get; set; }

        public int et_EventID { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal ed_Preis { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ed_Beginn { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ed_Ende { get; set; }

        [StringLength(50)]
        public string ed_StartOrt { get; set; } = null!;

        [StringLength(50)]
        public string? ed_Zielort { get; set; }

        public int ed_MaxTeilnehmer { get; set; }

        public int ed_AktTeilnehmer { get; set; }

        public bool ed_Freigegeben { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal ed_Rabatt { get; set; }

        public bool ed_VeranstalterBenachrichtigt { get; set; }

        [ForeignKey("et_EventID")]
        [InverseProperty("tbl_EventDaten")]
        public virtual tbl_Events et_Event { get; set; } = null!;

        [InverseProperty("ed_EvDaten")]
        public virtual ICollection<tbl_Buchungen> tbl_Buchungen { get; } = new List<tbl_Buchungen>();
    }
}
