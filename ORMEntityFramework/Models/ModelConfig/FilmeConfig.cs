using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ORMEntityFramework.Models.ModelConfig
{
    public class FilmeConfig : EntityTypeConfiguration<Filme>
    {
        public FilmeConfig()
        {
            HasKey(c => c.FilmeId);

            Property(c => c.Nome)
                .IsRequired();
        }
    }
}