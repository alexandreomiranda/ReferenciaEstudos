using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMVCBasico.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NomeCompleto { get { return Nome + " " + Sobrenome; } }

    }
}