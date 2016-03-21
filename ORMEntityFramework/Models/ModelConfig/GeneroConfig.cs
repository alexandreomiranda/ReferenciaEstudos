using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ORMEntityFramework.Models.ModelConfig
{
    public class GeneroConfig : EntityTypeConfiguration<Genero>
    {
        public GeneroConfig()
        {
            HasKey(c => c.GeneroId);

            Property(c => c.Nome)
                .IsRequired();

        }
    }
}