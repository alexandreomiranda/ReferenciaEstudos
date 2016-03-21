using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ORMEntityFramework.Context;
using ORMEntityFramework.Models;
using ORMEntityFramework.ViewModels;
using System.Data.Entity.Infrastructure;

namespace ORMEntityFramework.Controllers
{
    public class FilmesController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Filmes
        public ActionResult Index()
        {
            var filmes = db.Filmes.Include(f => f.Diretor);
            return View(filmes.ToList());
        }

        // GET: Filmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // GET: Filmes/Create
        public ActionResult Create()
        {
            ViewBag.DiretorId = new SelectList(db.Diretores, "DiretorId", "Nome");
            
            var filme = new Filme();
            filme.Generos = new List<Genero>();
            PopulateGeneroData(filme);
            return View();
        }

        private void PopulateGeneroData(Filme filme)
        {
            var allGenero = db.Generos;
            var filmeGeneros = new HashSet<int>(filme.Generos.Select(c => c.GeneroId));
            var viewModel = new List<FilmeGenero>();
            foreach (var genero in allGenero)
            {
                viewModel.Add(new FilmeGenero
                {
                    GeneroId = genero.GeneroId,
                    Nome = genero.Nome,
                    Selecionado = filmeGeneros.Contains(genero.GeneroId)
                });
            }
            ViewBag.Generos = viewModel;
        }
        // POST: Filmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmeId,Nome,Ano,DiretorId")] Filme filme, string[] selectedGeneros)
        {
            if (selectedGeneros != null)
            {
                filme.Generos = new List<Genero>();
                foreach (var item in selectedGeneros)
                {
                    var generoToAdd = db.Generos.Find(int.Parse(item));
                    filme.Generos.Add(generoToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                db.Filmes.Add(filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateGeneroData(filme);

            ViewBag.DiretorId = new SelectList(db.Diretores, "DiretorId", "Nome", filme.DiretorId);
            return View(filme);
        }

        // GET: Filmes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes
                .Include(c => c.Generos)
                .Where(c => c.FilmeId == id)
                .Single();
            PopulateGeneroData(filme);

            if (filme == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiretorId = new SelectList(db.Diretores, "DiretorId", "Nome", filme.DiretorId);
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] selectedGeneros)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var filmeToUpdate = db.Filmes
               .Include(i => i.Generos)
               .Where(i => i.FilmeId == id)
               .Single();

            if (TryUpdateModel(filmeToUpdate, "",
               new string[] { "Nome", "Ano", "DiretorId"}))
            {
                try
                {
                    UpdateFilmeGenero(selectedGeneros, filmeToUpdate);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateGeneroData(filmeToUpdate);
            ViewBag.DiretorId = new SelectList(db.Diretores, "DiretorId", "Nome", filmeToUpdate.DiretorId);
            return View(filmeToUpdate);
        }
        /*
        public ActionResult Edit([Bind(Include = "FilmeId,Nome,Ano,DiretorId")] Filme filme, string[] selectedGeneros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filme).State = EntityState.Modified;
                UpdateFilmeGenero(selectedGeneros, filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiretorId = new SelectList(db.Diretores, "DiretorId", "Nome", filme.DiretorId);
            return View(filme);
        }
        */ 
        private void UpdateFilmeGenero(string[] selectedGeneros, Filme filme)
        {
            if (selectedGeneros == null)
            {
                filme.Generos = new List<Genero>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedGeneros);
            var filmeGeneros = new HashSet<int>
                (filme.Generos.Select(c => c.GeneroId));
            foreach (var item in db.Generos)
            {
                if (selectedCoursesHS.Contains(item.GeneroId.ToString()))
                {
                    if (!filmeGeneros.Contains(item.GeneroId))
                    {
                        filme.Generos.Add(item);
                    }
                }
                else
                {
                    if (filmeGeneros.Contains(item.GeneroId))
                    {
                        filme.Generos.Remove(item);
                    }
                }
            }
        }
        // GET: Filmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = db.Filmes.Find(id);
            db.Filmes.Remove(filme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
