namespace ORMEntityFramework.Migrations
{
    using Context;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ORMEntityFramework.Context.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ORMEntityFramework.Context.EFContext context)
        {
            var diretores = new List<Diretor>{
                new Diretor{DiretorId=1,Nome="Roger Waters",DataNascimento=new DateTime(1970,02,28)},
                new Diretor{DiretorId=2,Nome="Clint Eastwood",DataNascimento=new DateTime(1970,03,28)},
                new Diretor{DiretorId=3,Nome="Ridley Scott",DataNascimento=new DateTime(1970,02,28)}
            };
            diretores.ForEach(s => context.Diretores.AddOrUpdate(p => p.Nome, s));
            context.SaveChanges();

            var generos = new List<Genero>{
                new Genero{GeneroId=1,Nome="Drama"},
                new Genero{GeneroId=2,Nome="Musical"},
                new Genero{GeneroId=3,Nome="Ação"}
            };
            generos.ForEach(s => context.Generos.AddOrUpdate(p => p.Nome, s));
            context.SaveChanges();

            var filmes = new List<Filme>{
                new Filme {FilmeId=100, Nome="The Wall",Ano=2005,
                DiretorId = diretores.Single( i => i.Nome == "Roger Waters").DiretorId,
                Generos = new List<Genero>()
                },
                new Filme {FilmeId=100, Nome="A Menina de Ouro",Ano=2005,
                DiretorId = diretores.Single( i => i.Nome == "Clint Eastwood").DiretorId,
                Generos = new List<Genero>()
                },
                new Filme {FilmeId=100, Nome="Blade Runner",Ano=2005,
                DiretorId = diretores.Single( i => i.Nome == "Ridley Scott").DiretorId,
                Generos = new List<Genero>()
                }
            };
            diretores.ForEach(s => context.Diretores.AddOrUpdate(p => p.DiretorId, s));
            context.SaveChanges();

            AddOrUpdateFilme(context, "Drama", "The Wall");
            AddOrUpdateFilme(context, "Musical", "The Wall");
            AddOrUpdateFilme(context, "Drama", "A Menina de Ouro");
            AddOrUpdateFilme(context, "Ação", "A Menina de Ouro");
            AddOrUpdateFilme(context, "Ação", "Blade Runner");
            context.SaveChanges();



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
        }
        void AddOrUpdateFilme(EFContext context, string generoTitle, string filmeName)
        {
            var crs = context.Generos.SingleOrDefault(c => c.Nome == generoTitle);
            var inst = crs.Filmes.SingleOrDefault(i => i.Nome == filmeName);
            if (inst == null)
                crs.Filmes.Add(context.Filmes.Single(i => i.Nome == filmeName));
        }
    }
}
