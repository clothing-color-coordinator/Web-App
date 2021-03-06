﻿// <auto-generated />
using ColorScheme.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ColorScheme.Migrations
{
    [DbContext(typeof(ColorSchemeDbContext))]
    [Migration("20190208015640_carlos20190207")]
    partial class carlos20190207
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ColorScheme.Models.ColorSchemeM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColorReceived");

                    b.Property<string>("ColorReceivedHex");

                    b.Property<string>("ColorReceivedHexTwo");

                    b.Property<string>("ColorReceivedTwo");

                    b.Property<string>("ColorSearched");

                    b.Property<string>("ColorSearchedHex");

                    b.Property<string>("SchemeType");

                    b.Property<int>("UserMID");

                    b.HasKey("ID");

                    b.HasIndex("UserMID");

                    b.ToTable("colorScheme");
                });

            modelBuilder.Entity("ColorScheme.Models.UserM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ColorScheme.Models.ColorSchemeM", b =>
                {
                    b.HasOne("ColorScheme.Models.UserM")
                        .WithMany("colorSchemes")
                        .HasForeignKey("UserMID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
