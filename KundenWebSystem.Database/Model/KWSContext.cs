using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KundenWebSystem.Database.Model;

public partial class KWSContext : DbContext
{
    public KWSContext()
    {
    }

    public KWSContext(DbContextOptions<KWSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<tbl_Buchungen> tbl_Buchungen { get; set; }

    public virtual DbSet<tbl_EvKategorie> tbl_EvKategorie { get; set; }

    public virtual DbSet<tbl_EvVeranstalter> tbl_EvVeranstalter { get; set; }

    public virtual DbSet<tbl_EventDaten> tbl_EventDaten { get; set; }

    public virtual DbSet<tbl_Events> tbl_Events { get; set; }

    public virtual DbSet<tbl_Kunden> tbl_Kunden { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=KBS;User=SA;Password=your_password123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tbl_Buchungen>(entity =>
        {
            entity.HasKey(e => e.bu_BuchungsID).HasName("tbl_Buchungen_PK");

            entity.HasOne(d => d.ed_EvDaten).WithMany(p => p.tbl_Buchungen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_EvDaten_tbl_Buchungen_FK1");

            entity.HasOne(d => d.kd_Kunden).WithMany(p => p.tbl_Buchungen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_Kunden_tbl_Buchungen_FK1");
        });

        modelBuilder.Entity<tbl_EvKategorie>(entity =>
        {
            entity.HasKey(e => e.ek_EvKategorieID).HasName("tbl_EvKategorie_PK");
        });

        modelBuilder.Entity<tbl_EvVeranstalter>(entity =>
        {
            entity.HasKey(e => e.ev_EvVeranstalterID).HasName("tbl_EvVeranstalter_PK");
        });

        modelBuilder.Entity<tbl_EventDaten>(entity =>
        {
            entity.HasKey(e => e.ed_EvDatenID).HasName("tbl_Events_PK");

            entity.HasOne(d => d.et_Event).WithMany(p => p.tbl_EventDaten)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_Events_tbl_EvDaten_FK1");
        });

        modelBuilder.Entity<tbl_Events>(entity =>
        {
            entity.HasKey(e => e.et_EventID).HasName("tbl_EvBeschreibung_PK");

            entity.HasOne(d => d.ek_EvKategorie).WithMany(p => p.tbl_Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_EvKategorie_tbl_Events_FK1");

            entity.HasOne(d => d.ev_EvVeranstalter).WithMany(p => p.tbl_Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_EvVeranstalter_tbl_Events_FK1");
        });

        modelBuilder.Entity<tbl_Kunden>(entity =>
        {
            entity.HasKey(e => e.kd_KundenID).HasName("tbl_Kunden_PK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
