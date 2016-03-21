using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginWebFormsMVC.Models
{
    [Table("Login")]
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("LoginId")]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("LoginNome")]
        public String Nome { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("LoginSenha")]
        [DataType(DataType.Password)]
        public String Senha { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}