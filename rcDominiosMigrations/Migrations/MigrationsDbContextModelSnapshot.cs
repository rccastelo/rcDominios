﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rcDominiosMigrations;

namespace rcDominiosMigrations.Migrations
{
    [DbContext(typeof(MigrationsDbContext))]
    partial class MigrationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("rcDominiosEntities.ContaBancariaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Alteracao");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Codigo")
                        .HasMaxLength(20);

                    b.Property<DateTime>("Criacao");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("ContaBancaria");
                });

            modelBuilder.Entity("rcDominiosEntities.CorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Alteracao");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Codigo")
                        .HasMaxLength(20);

                    b.Property<DateTime>("Criacao");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Cor");
                });

            modelBuilder.Entity("rcDominiosEntities.EnderecoTipoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Alteracao");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Codigo")
                        .HasMaxLength(20);

                    b.Property<DateTime>("Criacao");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("EnderecoTipo");
                });

            modelBuilder.Entity("rcDominiosEntities.EstadoCivilEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Alteracao");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Codigo")
                        .HasMaxLength(20);

                    b.Property<DateTime>("Criacao");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("EstadoCivil");
                });

            modelBuilder.Entity("rcDominiosEntities.PessoaTipoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Alteracao");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Codigo")
                        .HasMaxLength(20);

                    b.Property<DateTime>("Criacao");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("PessoaTipo");
                });

            modelBuilder.Entity("rcDominiosEntities.ProfissaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Alteracao");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Codigo")
                        .HasMaxLength(20);

                    b.Property<DateTime>("Criacao");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Profissao");
                });
#pragma warning restore 612, 618
        }
    }
}
