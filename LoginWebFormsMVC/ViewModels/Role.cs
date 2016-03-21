using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginWebFormsMVC.ViewModels
{
    public class Role
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public bool Selecionado { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
    }
}