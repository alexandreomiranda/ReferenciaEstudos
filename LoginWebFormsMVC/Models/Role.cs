using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginWebFormsMVC.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RoleId")]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("RoleNome")]
        public String Nome { get; set; }

        [NotMapped]
        public bool Selecionado { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}