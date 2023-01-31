using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KundenWebSystem.Database.Model;

public partial class tbl_Buchungen
{
    [Key]
    public int bu_BuchungsID { get; set; }

    public int kd_KundenID { get; set; }

    public int ed_EvDatenID { get; set; }

    public int bu_GebuchtePlaetze { get; set; }

    public bool bu_Bezahlt { get; set; }

    public bool bu_Storniert { get; set; }

    public bool bu_RechnungErstellt { get; set; }

    [ForeignKey("ed_EvDatenID")]
    [InverseProperty("tbl_Buchungen")]
    public virtual tbl_EventDaten ed_EvDaten { get; set; } = null!;

    [ForeignKey("kd_KundenID")]
    [InverseProperty("tbl_Buchungen")]
    public virtual tbl_Kunden kd_Kunden { get; set; } = null!;
}
