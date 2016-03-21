using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ORMEntityFramework.Models
{
    public class Filme
    {
        public Filme()
        {
            Generos = new List<Genero>();
        }
        public int FilmeId { get; set; }
        [Display(Name = "Filme")]
        public string Nome { get; set; }
        public int? Ano { get; set; }
        public int DiretorId { get; set; }
        public virtual Diretor Diretor { get; set; }
        public virtual ICollection<Genero> Generos { get; set; }
    }
}