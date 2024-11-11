using System;
using System.Collections.Generic;
using ApiBurgerNew.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBurgerNew.Data;

public partial class FogachoAleBurguer2Context : DbContext
{
    public FogachoAleBurguer2Context()
    {
    }

    public FogachoAleBurguer2Context(DbContextOptions<FogachoAleBurguer2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Burguer> Burguers { get; set; }

    public virtual DbSet<Promo> Promos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FogachoAleBurguer2");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Burguer>(entity =>
        {
            entity.ToTable("Burguer");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Promo>(entity =>
        {
            entity.ToTable("Promo");

            entity.HasIndex(e => e.BurguerId, "IX_Promo_BurguerId");

            entity.HasOne(d => d.Burguer).WithMany(p => p.Promos).HasForeignKey(d => d.BurguerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
