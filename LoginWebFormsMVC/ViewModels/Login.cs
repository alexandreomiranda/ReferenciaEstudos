using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginWebFormsMVC.ViewModels
{
    public class Login
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}