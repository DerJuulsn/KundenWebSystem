using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KundenWebSystem.Database.Model;

public partial class tbl_EvVeranstalter
{
    [Key]
    public int ev_EvVeranstalterID { get; set; }

    [StringLength(50)]
    public string ev_Firma { get; set; } = null!;

    [StringLength(50)]
    public string ev_Strasse { get; set; } = null!;

    [StringLength(10)]
    public string ev_PLZ { get; set; } = null!;

    [StringLength(10)]
    public string ev_HNummer { get; set; } = null!;

    [StringLength(50)]
    public string ev_Ort { get; set; } = null!;

    [StringLength(25)]
    public string? ev_Telefon { get; set; }

    [StringLength(50)]
    public string? ev_EMail { get; set; }

    [StringLength(50)]
    public string? ev_Fax { get; set; }

    [InverseProperty("ev_EvVeranstalter")]
    public virtual ICollection<tbl_Events> tbl_Events { get; } = new List<tbl_Events>();
}
