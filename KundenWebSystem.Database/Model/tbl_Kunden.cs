using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KundenWebSystem.Database.Model;

public partial class tbl_Kunden
{
    [Key]
    public int kd_KundenID { get; set; }

    [StringLength(50)]
    public string kd_Name { get; set; } = null!;

    [StringLength(50)]
    public string kd_Vorname { get; set; } = null!;

    [StringLength(50)]
    public string kd_Strasse { get; set; } = null!;

    [StringLength(10)]
    public string kd_HNummer { get; set; } = null!;

    [StringLength(10)]
    public string kd_PLZ { get; set; } = null!;

    [StringLength(50)]
    public string kd_Ort { get; set; } = null!;

    [StringLength(25)]
    public string? kd_Telefon { get; set; }

    [StringLength(50)]
    public string? kd_EMail { get; set; }

    [StringLength(255)]
    public string? kd_PasswortHash { get; set; }

    [InverseProperty("kd_Kunden")]
    public virtual ICollection<tbl_Buchungen> tbl_Buchungen { get; } = new List<tbl_Buchungen>();
}
