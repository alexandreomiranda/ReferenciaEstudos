using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ADOWebAppMVC.Context;
using ADOWebAppMVC.Models;
using ADOWebAppMVC.DAL;

namespace ADOWebAppMVC.Controllers
{
    public class ProdutosController : Controller
    {
        //private EFContext db = new EFContext();
        DALProduto DAL = new DALProduto();

        // GET: Produtos
        public ActionResult Index()
        {
            //return View(db.Produtos.ToList());
            return View(DAL.Get().ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id = 0)
        {
            
            //Produto produto = db.Produtos.Find(id);
            Produto produto = DAL.GetById(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,Nome,Preco,Estoque")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                //db.Produtos.Add(produto);
                //db.SaveChanges();
                DAL.Cadastra(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id = 0)
        {
            //Produto produto = db.Produtos.Find(id);
            Produto produto = DAL.GetById(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProdutoId,Nome,Preco,Estoque")] Produto produto)
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(produto).State = EntityState.Modified;
                //db.SaveChanges();
                DAL.Atualiza(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id = 0)
        {
            //Produto produto = db.Produtos.Find(id);
            Produto produto = DAL.GetById(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Produto produto = db.Produtos.Find(id);
            //db.Produtos.Remove(produto);
            //db.SaveChanges();
            DAL.Exclui(id);
            return RedirectToAction("Index");
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
         */
    }
}
