using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KundenWebSystem.Database.Model
{
    public partial class tbl_EvKategorie
    {
        [Key]
        public int ek_EvKategorieID { get; set; }

        [StringLength(15)]
        public string ek_KatBezeichnung { get; set; } = null!;

        [InverseProperty("ek_EvKategorie")]
        public virtual ICollection<tbl_Events> tbl_Events { get; } = new List<tbl_Events>();
    }
}
