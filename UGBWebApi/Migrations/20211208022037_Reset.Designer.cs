﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UGBWebApi.Context;

namespace UGBWebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211208022037_Reset")]
    partial class Reset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UGBWebApi.Models.Parada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProducaoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Tempo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProducaoId");

                    b.ToTable("Paradas");
                });

            modelBuilder.Entity("UGBWebApi.Models.Perda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProducaoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Qtde")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProducaoId");

                    b.ToTable("Perdas");
                });

            modelBuilder.Entity("UGBWebApi.Models.Producao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Fechado")
                        .HasColumnType("bit");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<decimal>("QtdeProduzida")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SetorId")
                        .HasColumnType("int");

                    b.Property<int?>("TurnoId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("SetorId");

                    b.HasIndex("TurnoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Producoes");
                });

            modelBuilder.Entity("UGBWebApi.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Caixa")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Qtde")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QtdeEstimativa")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("UGBWebApi.Models.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("HorasProducao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("UGBWebApi.Models.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qtde")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("UGBWebApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("UGBWebApi.Models.Parada", b =>
                {
                    b.HasOne("UGBWebApi.Models.Producao", null)
                        .WithMany("ListParadas")
                        .HasForeignKey("ProducaoId");
                });

            modelBuilder.Entity("UGBWebApi.Models.Perda", b =>
                {
                    b.HasOne("UGBWebApi.Models.Producao", null)
                        .WithMany("ListPerdas")
                        .HasForeignKey("ProducaoId");
                });

            modelBuilder.Entity("UGBWebApi.Models.Producao", b =>
                {
                    b.HasOne("UGBWebApi.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.HasOne("UGBWebApi.Models.Setor", "Setor")
                        .WithMany()
                        .HasForeignKey("SetorId");

                    b.HasOne("UGBWebApi.Models.Turno", "Turno")
                        .WithMany()
                        .HasForeignKey("TurnoId");

                    b.HasOne("UGBWebApi.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Produto");

                    b.Navigation("Setor");

                    b.Navigation("Turno");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("UGBWebApi.Models.Producao", b =>
                {
                    b.Navigation("ListParadas");

                    b.Navigation("ListPerdas");
                });
#pragma warning restore 612, 618
        }
    }
}
