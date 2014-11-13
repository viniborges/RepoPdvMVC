using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PDV.Models;
using PDV.DAL;

namespace PDV.Controllers
{
    public class FornecedorController : BaseController
    {
        private Contexto db = new Contexto();

        // GET: /Fornecedor/
        public async Task<ActionResult> Index()
        {
            var pessoas = db.Fornecedors.Include(f => f.Endereco);
            return View(await pessoas.ToListAsync());
        }

        // GET: /Fornecedor/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = (Fornecedor) await db.Pessoas.FindAsync(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // GET: /Fornecedor/Create
        public ActionResult Create()
        {
            ViewBag.PessoaId = new SelectList(db.Enderecos, "PessoaId", "Logradouro");
            return View();
        }

        // POST: /Fornecedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="PessoaId,Email,CPFCNPJ,Nome,FornecedorId,InscricaoEstadual,UltimaCompra")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(fornecedor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PessoaId = new SelectList(db.Enderecos, "PessoaId", "Logradouro", fornecedor.PessoaId);
            return View(fornecedor);
        }

        // GET: /Fornecedor/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = (Fornecedor) await db.Pessoas.FindAsync(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaId = new SelectList(db.Enderecos, "PessoaId", "Logradouro", fornecedor.PessoaId);
            return View(fornecedor);
        }

        // POST: /Fornecedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="PessoaId,Email,CPFCNPJ,Nome,FornecedorId,InscricaoEstadual,UltimaCompra")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaId = new SelectList(db.Enderecos, "PessoaId", "Logradouro", fornecedor.PessoaId);
            return View(fornecedor);
        }

        // GET: /Fornecedor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = (Fornecedor) await db.Pessoas.FindAsync(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: /Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fornecedor fornecedor = (Fornecedor) await db.Pessoas.FindAsync(id);
            db.Pessoas.Remove(fornecedor);
            await db.SaveChangesAsync();
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
