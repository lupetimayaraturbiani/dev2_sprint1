﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senai.InLock.WebApi.CodeFirst.Context;

namespace Senai.InLock.WebApi.CodeFirst.Migrations
{
    [DbContext(typeof(InLockContext))]
    [Migration("20200310164519_Cria-Banco")]
    partial class CriaBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Senai.InLock.WebApi.CodeFirst.Domains.Estudios", b =>
                {
                    b.Property<int>("IdEstudio")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeEstudio")
                        .IsRequired()
                        .HasColumnType("VARCHAR (255)");

                    b.HasKey("IdEstudio");

                    b.ToTable("Estudios");

                    b.HasData(
                        new { IdEstudio = 1, NomeEstudio = "Blizzard" },
                        new { IdEstudio = 2, NomeEstudio = "Rockstar Studios" },
                        new { IdEstudio = 3, NomeEstudio = "Square Enix" }
                    );
                });

            modelBuilder.Entity("Senai.InLock.WebApi.CodeFirst.Domains.Jogos", b =>
                {
                    b.Property<int>("IdJogo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdEstudio");

                    b.Property<string>("NomeJogo")
                        .IsRequired()
                        .HasColumnType("VARCHAR (150)");

                    b.Property<decimal>("Valor")
                        .HasColumnName("Preço")
                        .HasColumnType("DECIMAL (18,2)");

                    b.HasKey("IdJogo");

                    b.HasIndex("IdEstudio");

                    b.ToTable("Jogos");

                    b.HasData(
                        new { IdJogo = 1, DataLancamento = new DateTime(2012, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), Descricao = "É um jogo que contém bastante ação e é viciante, seja você um novato ou fã", IdEstudio = 1, NomeJogo = "Diablo 3", Valor = 99.00m },
                        new { IdJogo = 2, DataLancamento = new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), Descricao = "Jogo eletrônico de ação-aventura western", IdEstudio = 2, NomeJogo = "Red Dead Redemption II", Valor = 120.00m }
                    );
                });

            modelBuilder.Entity("Senai.InLock.WebApi.CodeFirst.Domains.TipoUsuario", b =>
                {
                    b.Property<int>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR (255)");

                    b.HasKey("IdTipoUsuario");

                    b.ToTable("TipoUsuarios");

                    b.HasData(
                        new { IdTipoUsuario = 1, Titulo = "Administrador" },
                        new { IdTipoUsuario = 2, Titulo = "Comum" }
                    );
                });

            modelBuilder.Entity("Senai.InLock.WebApi.CodeFirst.Domains.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR (255)");

                    b.Property<int>("IdTipoUsuario");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR (255)")
                        .HasMaxLength(30);

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new { IdUsuario = 1, Email = "admin@admin.com", IdTipoUsuario = 1, Senha = "admin" },
                        new { IdUsuario = 2, Email = "cliente@cliente.com", IdTipoUsuario = 2, Senha = "cliente" }
                    );
                });

            modelBuilder.Entity("Senai.InLock.WebApi.CodeFirst.Domains.Jogos", b =>
                {
                    b.HasOne("Senai.InLock.WebApi.CodeFirst.Domains.Estudios", "Estudios")
                        .WithMany("Jogos")
                        .HasForeignKey("IdEstudio")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Senai.InLock.WebApi.CodeFirst.Domains.Usuarios", b =>
                {
                    b.HasOne("Senai.InLock.WebApi.CodeFirst.Domains.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
