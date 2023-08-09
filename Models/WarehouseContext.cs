using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class WarehouseContext : DbContext
    {
        public WarehouseContext()
        {
        }

        public WarehouseContext(DbContextOptions<WarehouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Dealer> Dealers { get; set; } = null!;
        public virtual DbSet<Dumpy> Dumpies { get; set; } = null!;
        public virtual DbSet<Good> Goods { get; set; } = null!;
        public virtual DbSet<LoginTab> LoginTabs { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=BSCHNL-15878\\SQLEXPRESS;Database=Warehouse;Trusted_Connection=True;encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__cart__D837D05FEA94B7B5");

                entity.ToTable("cart");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Dateoforder)
                    .HasColumnType("date")
                    .HasColumnName("dateoforder")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Oid).HasColumnName("oid");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.HasOne(d => d.OidNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Oid)
                    .HasConstraintName("FK__cart__oid__71D1E811");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK__cart__pid__6FE99F9F");
            });

            modelBuilder.Entity<Dealer>(entity =>
            {
                entity.ToTable("Dealer");

                entity.Property(e => e.DealerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Dealer_Id");

                entity.Property(e => e.DealerName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Dealer_Name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Phone_No");
            });

            modelBuilder.Entity<Dumpy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dumpy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Goods__9834FBBA652884B1");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product_Id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Product_name");
            });

            modelBuilder.Entity<LoginTab>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__Login_ta__A9D10535B0F94560");

                entity.ToTable("Login_tab");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Order_de__F1E4607B758A8E18");

                entity.ToTable("Order_detail");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("Order_Id");

                entity.Property(e => e.DealerId).HasColumnName("Dealer_Id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("Order_date");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dealer)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.DealerId)
                    .HasConstraintName("FK__Order_det__Deale__3B75D760");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Order_det__Produ__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
