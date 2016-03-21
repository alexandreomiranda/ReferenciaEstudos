using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVCBasico.Models;

namespace WebAppMVCBasico.Controllers
{
    public class ClienteController : Controller
    {
        public static List<Cliente> GetData()
        {
            var dados = new List<Cliente>(){
                new Cliente(){ ClienteId=1, Nome="Maria", Sobrenome="Luiza", DataCadastro=DateTime.Now},
                new Cliente(){ ClienteId=2, Nome="Vitor", Sobrenome="Miranda", DataCadastro=new DateTime(2009,12,30)},
                new Cliente(){ ClienteId=3, Nome="Maria", Sobrenome="Aparecida", DataCadastro=new DateTime(2010,04,25)},
                new Cliente(){ ClienteId=4, Nome="João", Sobrenome="Pedro", DataCadastro=new DateTime(2011,05,22)},
                new Cliente(){ ClienteId=5, Nome="Pedro", Sobrenome="Gabriel", DataCadastro=new DateTime(2015,11,18)}
            };
            return dados;
        }

        // GET: Clientes - Lista com opção de deletar linha via JQuery
        public ActionResult Index()
        {
            var listaClientes = GetData();
            return View(listaClientes);
        }
        // GET: Clientes - Busca por Id e uso de TempData
        public ActionResult Buscar(int? id)
        {
            var listaClientes = GetData();
            var busca = listaClientes.Where(c => c.ClienteId == id).ToList();
            if (!busca.Any())
            {
                TempData["erro"] = "Cliente ID "+id+" não encontrado";
            }
            return View("Index", busca);
        }
        // GET: Clientes - Passando dados para a View através da ViewBag
        public ActionResult ListarVB()
        {
            ViewBag.listaCliente = GetData();
            return View();
        }
    }
}