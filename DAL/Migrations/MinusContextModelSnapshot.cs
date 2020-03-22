﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(MinusContext))]
    partial class MinusContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Entity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<short>("EmailConfirmed")
                        .HasColumnType("BIT(1)");

                    b.Property<short>("LockoutEnabled")
                        .HasColumnType("BIT(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(85);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(85);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<short>("PhoneNumberConfirmed")
                        .HasColumnType("BIT(1)");

                    b.Property<int?>("ProfilePhotoId");

                    b.Property<string>("SecurityStamp");

                    b.Property<short>("TwoFactorEnabled")
                        .HasColumnType("BIT(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("ProfilePhotoId")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Entity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("CustomerId")
                        .IsRequired();

                    b.Property<short>("IsVisible")
                        .HasColumnType("BIT(1)");

                    b.Property<int?>("ProductId");

                    b.Property<DateTime>("PublishDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Entity.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PartnerId");

                    b.Property<string>("PhysicalPath")
                        .IsRequired();

                    b.Property<int?>("ProductId");

                    b.Property<string>("RelativePath");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("Entity.Counter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PartnerId");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("Counters");
                });

            modelBuilder.Entity("Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CounterId");

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderStatusId");

                    b.Property<int>("OrderTypeId");

                    b.Property<int>("PartnerId");

                    b.Property<int>("PaymentTypeId");

                    b.Property<string>("SessionId")
                        .IsRequired();

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("Id");

                    b.HasIndex("CounterId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("OrderTypeId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entity.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Entity.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            Name = "BASKET"
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Name = "CONFIRMED"
                        },
                        new
                        {
                            Id = 6,
                            Description = "",
                            Name = "CANCELLED"
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            Name = "PREPARING"
                        },
                        new
                        {
                            Id = 4,
                            Description = "",
                            Name = "DELIVERY"
                        },
                        new
                        {
                            Id = 5,
                            Description = "",
                            Name = "COMPLETED"
                        });
                });

            modelBuilder.Entity("Entity.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("OrderTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            Name = "HERE"
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Name = "AWAY"
                        });
                });

            modelBuilder.Entity("Entity.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssociateAddress")
                        .IsRequired();

                    b.Property<string>("AssociateName")
                        .IsRequired();

                    b.Property<string>("AssociateUrl")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("Entity.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Description = "",
                            Name = "CASH"
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Name = "MOBILE"
                        },
                        new
                        {
                            Id = 1,
                            Description = "",
                            Name = "CARD"
                        });
                });

            modelBuilder.Entity("Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("AwayOrderAvailable")
                        .HasColumnType("BIT(1)");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<short>("IsInStock")
                        .HasColumnType("BIT(1)");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ProductVolumeUnit");

                    b.Property<double>("Rating");

                    b.Property<decimal>("TotalProductVolume");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Entity.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContentId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PartnerId");

                    b.HasKey("Id");

                    b.HasIndex("ContentId")
                        .IsUnique();

                    b.HasIndex("PartnerId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Entity.ProductOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TypeId");

                    b.ToTable("ProductOptions");
                });

            modelBuilder.Entity("Entity.ProductOptionItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AdditionalPrice");

                    b.Property<string>("Description");

                    b.Property<int>("ProductOptionId");

                    b.Property<bool>("Selected");

                    b.HasKey("Id");

                    b.HasIndex("ProductOptionId");

                    b.ToTable("ProductOptionItems");
                });

            modelBuilder.Entity("Entity.ProductOptionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProductOptionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            Name = "EXCLUDE"
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Name = "RADIO"
                        },
                        new
                        {
                            Id = 4,
                            Description = "",
                            Name = "SELECT"
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            Name = "CHECKBOX"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(85);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(85);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(85);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(85);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(85);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(85);

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(85);

                    b.Property<string>("RoleId")
                        .HasMaxLength(85);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(85);

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(85);

                    b.Property<string>("Name")
                        .HasMaxLength(85);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Entity.ApplicationUser", b =>
                {
                    b.HasOne("Entity.Content", "ProfilePhoto")
                        .WithOne("Customer")
                        .HasForeignKey("Entity.ApplicationUser", "ProfilePhotoId");
                });

            modelBuilder.Entity("Entity.Comment", b =>
                {
                    b.HasOne("Entity.ApplicationUser", "Customer")
                        .WithMany("Comments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entity.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Entity.Content", b =>
                {
                    b.HasOne("Entity.Partner", "Partner")
                        .WithMany("Contents")
                        .HasForeignKey("PartnerId");

                    b.HasOne("Entity.Product", "Product")
                        .WithMany("Contents")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Entity.Counter", b =>
                {
                    b.HasOne("Entity.Partner", "Partner")
                        .WithMany("Counters")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.Order", b =>
                {
                    b.HasOne("Entity.Counter", "Counter")
                        .WithMany("Orders")
                        .HasForeignKey("CounterId");

                    b.HasOne("Entity.ApplicationUser", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Entity.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entity.OrderType", "OrderType")
                        .WithMany("Orders")
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entity.Partner", "Partner")
                        .WithMany("Orders")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entity.PaymentType", "PaymentType")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.OrderProduct", b =>
                {
                    b.HasOne("Entity.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entity.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.Product", b =>
                {
                    b.HasOne("Entity.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.ProductCategory", b =>
                {
                    b.HasOne("Entity.Content", "Content")
                        .WithOne("ProductCategory")
                        .HasForeignKey("Entity.ProductCategory", "ContentId");

                    b.HasOne("Entity.Partner", "Partner")
                        .WithMany("ProductCategories")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.ProductOption", b =>
                {
                    b.HasOne("Entity.Order", "Order")
                        .WithMany("ProductOptions")
                        .HasForeignKey("OrderId");

                    b.HasOne("Entity.Product")
                        .WithMany("Options")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entity.ProductOptionType", "Type")
                        .WithMany("ProductOptions")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.ProductOptionItem", b =>
                {
                    b.HasOne("Entity.ProductOption", "ProductOption")
                        .WithMany("Items")
                        .HasForeignKey("ProductOptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
