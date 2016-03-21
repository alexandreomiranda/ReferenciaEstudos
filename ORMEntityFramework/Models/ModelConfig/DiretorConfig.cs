using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ORMEntityFramework.Models.ModelConfig
{
    public class DiretorConfig : EntityTypeConfiguration<Diretor>
    {
        public DiretorConfig()
        {
            HasKey(c => c.DiretorId);

            Property(c => c.Nome)
                .IsRequired();

        }
    }
}