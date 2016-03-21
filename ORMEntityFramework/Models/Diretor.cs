using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ORMEntityFramework.Models
{
    public class Diretor
    {
        public Diretor()
        {
            Filmes = new List<Filme>();
        }
        public int DiretorId { get; set; }
        [Display(Name = "Diretor")]
        public string Nome { get; set; }
        public virtual ICollection<Filme> Filmes { get; set; }

    }
}