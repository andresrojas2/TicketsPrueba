using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebasTicket.Models.Models
{
    public partial class PruebasTicketContext : DbContext
    {
        public PruebasTicketContext()
        {
        }

        public PruebasTicketContext(DbContextOptions<PruebasTicketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EstatusTicket> EstatusTickets { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-JDL66LH\\SQLEXPRESS2019;Database= PruebasTicket; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<EstatusTicket>(entity =>
            {
                entity.ToTable("EstatusTicket");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstatusTicket)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.EstatusTicketId)
                    .HasConstraintName("FK_Ticket_EstatusTicket");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
