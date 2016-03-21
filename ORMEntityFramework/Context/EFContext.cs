using ORMEntityFramework.Models;
using ORMEntityFramework.Models.ModelConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ORMEntityFramework.Context
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("ORMEntityFramework")
        {

        }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new FilmeConfig());
            modelBuilder.Configurations.Add(new GeneroConfig());
            modelBuilder.Configurations.Add(new DiretorConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}