using ADOWebAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ADOWebAppMVC.Context
{
	public class EFContext : DbContext
	{
		public EFContext ()
			: base("ADOWebAppMVC")
		{

		}
		public DbSet<Produto> Produtos { get; set; }

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
			
			modelBuilder.Configurations.Add(new ProdutoConfig());

			base.OnModelCreating(modelBuilder);
		}
	}
}