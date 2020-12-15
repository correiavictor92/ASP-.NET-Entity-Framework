using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Impl;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PessoaController : Controller
    {

        // GET: /Pessoa/
        public ActionResult Index()
        {
            ViewBag.Mensagem = "Minha primeira View";
            return View();
        }


        // GET: /Create/
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Create/
        [HttpPost]
        public ActionResult Create(Pessoa model)
        {
            if (ModelState.IsValid)
            {
                PessoaService srv = new PessoaService();
                srv.Salvar(model);

                return View("List", srv.Listar());
            }
            else
                return View(model);
        }

        // GET : /List/
        public ActionResult List()
        {
            PessoaService srv = new PessoaService();

            return View(srv.Listar());
        }

        // GET: /Edit/
        public ActionResult Edit(int id)
        {
            var srv = new PessoaService();
            srv.Obter(id);

            return View("Create", srv.Obter(id));
        }

        // POST: /Edit/
        [HttpPost]
        public ActionResult Edit(Pessoa model)
        {
            if (ModelState.IsValid)
            {
                PessoaService srv = new PessoaService();
                srv.Salvar(model);

                return View("List", srv.Listar());
            }
            else
                return View("Create", model);
        }

        public ActionResult Delete(int id)
        {
            PessoaService srv = new PessoaService();
            srv.Deletar(id);

            return View("List", srv.Listar());
        }
	}
}