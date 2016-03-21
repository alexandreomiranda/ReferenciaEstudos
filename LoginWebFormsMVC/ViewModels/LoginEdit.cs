using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginWebFormsMVC.ViewModels
{
    public class LoginEdit
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public String Nome { get; set; }

        [Required]
        [MaxLength(10)]
        [DataType(DataType.Password)]
        public String Senha { get; set; }

        [Required]
        [MaxLength(10)]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        [Display(Name = "Digite novamente")]
        public String ConfirmacaoSenha { get; set; }
    }
}