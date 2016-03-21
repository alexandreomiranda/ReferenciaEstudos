namespace ADOWebAppMVC.Migrations
{
    using ADOWebAppMVC.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ADOWebAppMVC.Context.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ADOWebAppMVC.Context.EFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            new List<Produto>{
                new Produto{Nome="Notebook", Preco=1500, Estoque=5},
                new Produto{Nome="Desktop", Preco=1000, Estoque=20},
                new Produto{Nome="Tablet", Preco=400, Estoque=30},
                new Produto{Nome="Smartphone", Preco=1200, Estoque=15}
            }.ForEach(s => context.Produtos.AddOrUpdate(p => p.ProdutoId, s));
            context.SaveChanges();
        }
    }
}
