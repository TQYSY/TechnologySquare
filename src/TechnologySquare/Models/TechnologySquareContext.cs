using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TechnologySquare.Models
{
    public partial class TechnologySquareContext : DbContext
    {
        public TechnologySquareContext(DbContextOptions<TechnologySquareContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK_Order");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Customermessage).HasColumnName("customermessage");

                entity.Property(e => e.OrderTime)
                    .HasColumnName("orderTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ThePayment).HasColumnName("thePayment");

                entity.Property(e => e.TheProduct).HasColumnName("theProduct");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK_Payment");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountNo)
                    .HasColumnName("accountNo")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ThePaymentType).HasColumnName("thePaymentType");

                entity.Property(e => e.TransNo)
                    .HasColumnName("transNo")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.TransTime)
                    .HasColumnName("transTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK_PaymentType");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.MethodName)
                    .IsRequired()
                    .HasColumnName("methodName")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("typeName")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK_Product");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("productID")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasColumnName("productname")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Productclass>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK_productclass");

                entity.ToTable("productclass");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.TheProduct).HasColumnName("theProduct");

                entity.Property(e => e.TheProductType).HasColumnName("theProductType");
            });

            modelBuilder.Entity<Producttype>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK_producttype");

                entity.ToTable("producttype");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK_Role");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK_User");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.TheRole)
                    .IsRequired()
                    .HasColumnName("theRole")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("nchar(10)");
            });
        }

        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Productclass> Productclass { get; set; }
        public virtual DbSet<Producttype> Producttype { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        // Unable to generate entity type for table 'dbo.customer information'. Please see the warning messages.
    }
}