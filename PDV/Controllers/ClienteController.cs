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
    public class ClienteController : BaseController
    {
        private Contexto db = new Contexto();

        // GET: /Cliente/
        public async Task<ActionResult> Index()
        {
            var pessoas = db.Clientes.Include(c => c.Endereco);
            return View(await pessoas.ToListAsync());
        }

        // GET: /Cliente/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = (Cliente) await db.Pessoas.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: /Cliente/Create
        public ActionResult Create()
        {
            ViewBag.PessoaId = new SelectList(db.Enderecos, "PessoaId", "Logradouro");
            return View();
        }

        // POST: /Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="PessoaId,Email,CPFCNPJ,Nome,ClienteId,Contato,UltimaVenda")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(cliente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PessoaId = new SelectList(db.Enderecos, "PessoaId", "Logradouro", cliente.PessoaId);
            return View(cliente);
        }

        // GET: /Cliente/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = (Cliente) await db.Pessoas.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaId = new SelectList(db.Enderecos, "PessoaId", "Logradouro", cliente.PessoaId);
            return View(cliente);
        }

        // POST: /Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="PessoaId,Email,CPFCNPJ,Nome,ClienteId,Contato,UltimaVenda")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaId = new SelectList(db.Enderecos, "PessoaId", "Logradouro", cliente.PessoaId);
            return View(cliente);
        }

        // GET: /Cliente/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = (Cliente) await db.Pessoas.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: /Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cliente cliente = (Cliente) await db.Pessoas.FindAsync(id);
            db.Pessoas.Remove(cliente);
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
