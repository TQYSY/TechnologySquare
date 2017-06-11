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
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK_AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.ProviderKey).HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserRoles_UserId");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PK_AspNetUserTokens");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Customer__530A63AC54A57AA9");

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.Adress).HasColumnType("nchar(256)");


                entity.Property(e => e.Conname).HasColumnType("nchar(256)");

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("mobilePhone")
                    .HasMaxLength(18);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(20);

            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Orders__530A63AC42DA0699");

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.Customermessage).HasColumnName("customermessage");

                entity.Property(e => e.OrderState).HasColumnName("orderState");

                entity.Property(e => e.OrderTime)
                    .HasColumnName("orderTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ThePayment).HasColumnName("thePayment");

                entity.Property(e => e.TheProduct).HasColumnName("theProduct");


                entity.HasOne(d => d.CustomermessageNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Customermessage)
                    .HasConstraintName("FK__Orders__customer__22751F6C");

                entity.HasOne(d => d.ThePaymentNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ThePayment)
                    .HasConstraintName("FK__Orders__thePayme__245D67DE");

                entity.HasOne(d => d.TheProductNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TheProduct)
                    .HasConstraintName("FK__Orders__theProdu__236943A5");

            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Payment__530A63AC630AAB5A");

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.AccountNo)
                    .HasColumnName("accountNo")
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.PaymentState).HasColumnName("paymentState");

                entity.Property(e => e.ThePaymentType).HasColumnName("thePaymentType");

                entity.Property(e => e.TransNo)
                    .HasColumnName("transNo")
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.TransTime)
                    .HasColumnName("transTime")
                    .HasColumnType("datetime");


                entity.HasOne(d => d.ThePaymentTypeNavigation)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.ThePaymentType)
                    .HasConstraintName("FK__Payment__thePaym__2739D489");

            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__PaymentT__530A63AC4063A7CB");

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.MethodName)
                    .HasColumnName("methodName")
                    .HasColumnType("nchar(256)");

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasColumnType("nchar(256)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("nchar(256)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Product__530A63ACE0E2C447");

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productID")
                    .HasMaxLength(100);

                entity.Property(e => e.Product_Img)
                    .HasColumnName("product_img")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Productname)
                    .HasColumnName("productname")
                    .HasMaxLength(256);

                entity.Property(e => e.ProductState).HasColumnName("productState");
            });

            modelBuilder.Entity<Productclass>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Productc__530A63ACC0BED782");

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.TheProduct).HasColumnName("theProduct");

                entity.Property(e => e.TheProductType).HasColumnName("theProductType");

                entity.HasOne(d => d.TheProductNavigation)
                    .WithMany(p => p.Productclass)
                    .HasForeignKey(d => d.TheProduct)
                    .HasConstraintName("FK__Productcl__thePr__2BFE89A6");

                entity.HasOne(d => d.TheProductTypeNavigation)
                    .WithMany(p => p.Productclass)
                    .HasForeignKey(d => d.TheProductType)
                    .HasConstraintName("FK__Productcl__thePr__2CF2ADDF");
            });

            modelBuilder.Entity<Producttype>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Productt__530A63AC5001A91E");

                entity.Property(e => e.ObjId).HasColumnName("objID");

                entity.Property(e => e.ClassType)
                    .HasColumnName("classType")
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Type).HasColumnType("nchar(100)");
            });
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Productclass> Productclass { get; set; }
        public virtual DbSet<Producttype> Producttype { get; set; }
    }
}