using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Anti_Cafe.DAL.Models;

public partial class AnticafeContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public AnticafeContext()
    {
    }

    public AnticafeContext(DbContextOptions<AnticafeContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Statuette> Statuettes { get; set; }

    public virtual DbSet<Table> Tables { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
           
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Receipt");

            entity.Property(e => e.Admin).HasMaxLength(450);
            entity.Property(e => e.Id).HasMaxLength(450);
            entity.Property(e => e.TimeIn).HasColumnType("datetime");
            entity.Property(e => e.TimeOut).HasColumnType("datetime");
            entity.Property(e => e.Value)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(450);
            entity.Property(e => e.Table).HasMaxLength(450);
            entity.Property(e => e.TimeIn).HasColumnType("datetime");
            entity.Property(e => e.TimeOut).HasColumnType("datetime");

            entity.HasOne(d => d.TableNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Table)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservations_Tables");
        });

        modelBuilder.Entity<Statuette>(entity =>
        {
            entity.ToTable("Statuette");

            entity.Property(e => e.Name)
                .HasMaxLength(450)
                .IsFixedLength();
            entity.Property(e => e.TimeIn).HasColumnType("datetime");
            entity.Property(e => e.TimeOut).HasColumnType("datetime");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(450);
            entity.Property(e => e.Statuette).HasMaxLength(450);

            entity.HasOne(d => d.StatuetteNavigation).WithMany(p => p.Tables)
                .HasForeignKey(d => d.Statuette)
                .HasConstraintName("FK_Tables_Statuette");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
