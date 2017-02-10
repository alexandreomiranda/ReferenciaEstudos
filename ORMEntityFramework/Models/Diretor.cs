using ORMEntityFramework.Models.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required(ErrorMessage = "O campo Diretor é obrigatório.")]
        public string Nome { get; set; }
        
        [Column(TypeName = "DateTime2")]
        //[MaiorDeIdade]
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }

    }
}