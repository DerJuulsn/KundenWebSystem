using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KundenWebSystem.Database.Model;

public partial class tbl_Events
{
    [Key]
    public int et_EventID { get; set; }

    public int ev_EvVeranstalterID { get; set; }

    public int ek_EvKategorieID { get; set; }

    [StringLength(50)]
    public string et_Bezeichnung { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? et_Beschreibung { get; set; }

    [ForeignKey("ek_EvKategorieID")]
    [InverseProperty("tbl_Events")]
    public virtual tbl_EvKategorie ek_EvKategorie { get; set; } = null!;

    [ForeignKey("ev_EvVeranstalterID")]
    [InverseProperty("tbl_Events")]
    public virtual tbl_EvVeranstalter ev_EvVeranstalter { get; set; } = null!;

    [InverseProperty("et_Event")]
    public virtual ICollection<tbl_EventDaten> tbl_EventDaten { get; } = new List<tbl_EventDaten>();
}
