using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HD.Test.Models
{
    public partial class QLSContext : DbContext
    {
        public QLSContext()
        {
        }

        public QLSContext(DbContextOptions<QLSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoaiSach> LoaiSaches { get; set; }
        public virtual DbSet<NhaXb> NhaXbs { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NNKUAAD\\KIMTT514;Database=QLS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiSach>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__LoaiSach__3E1DB46D4136AE9E");

                entity.ToTable("LoaiSach");

                entity.Property(e => e.Tenloai).HasMaxLength(30);
            });

            modelBuilder.Entity<NhaXb>(entity =>
            {
                entity.HasKey(e => e.MaXb)
                    .HasName("PK__NhaXb__272520CA02385222");

                entity.ToTable("NhaXb");

                entity.Property(e => e.Diachi).HasMaxLength(30);

                entity.Property(e => e.Ghichu).HasMaxLength(30);

                entity.Property(e => e.Tenxb).HasMaxLength(30);
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.Masach)
                    .HasName("PK__Sach__9F923C88A9B32A5F");

                entity.ToTable("Sach");

                entity.Property(e => e.Tacgia).HasMaxLength(30);

                entity.Property(e => e.Tensach).HasMaxLength(30);

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("F_2");

                entity.HasOne(d => d.MaxbNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Maxb)
                    .HasConstraintName("F_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
