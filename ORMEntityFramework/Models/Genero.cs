using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ORMEntityFramework.Models
{
    public class Genero
    {
        public Genero()
        {
            Filmes = new List<Filme>();
        }
        public int GeneroId { get; set; }
        [Display(Name = "Genero")]
        [Required(ErrorMessage = "O campo Genero é obrigatório.")]
        public string Nome { get; set; }
        public virtual ICollection<Filme> Filmes { get; set; }

    }
}