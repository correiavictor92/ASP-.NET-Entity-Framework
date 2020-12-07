using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            List<Pessoa> lista = new List<Pessoa>();

            if (ModelState.IsValid)
            {
                if (Session["ListaPessoas"] != null)
                {
                    lista.AddRange((List<Pessoa>)Session["ListaPessoas"]);
                }

                model.Id = lista.Count + 1;

                lista.Add(model);
                Session["ListaPessoas"] = lista;
            }
            else
                return View(model);
            return View("List", lista);
        }

        // GET : /List/
        public ActionResult List()
        {
            if (Session["ListaPessoas"] != null)
            {
                var model = (List<Pessoa>)Session["ListaPessoas"];
                return View(model);
            }

            return View(new List<Pessoa>());
        }


        // GET: /Edit/
        public ActionResult Edit(int id)
        {
            //Recuperar o objeto com o id
            //Enviar o objeto encontrado para a View de Edição

            if (((List<Pessoa>)Session["ListaPessoas"]).Where(p => p.Id == id).Any())
            {
                var model = ((List<Pessoa>)Session["ListaPessoas"])
                    .Where(p => p.Id == id).FirstOrDefault();

                return View("Create", model);
            }

            return View("Create", new Pessoa());
        }

        // POST: /Edit/
        [HttpPost]
        public ActionResult Edit(Pessoa model)
        {
            //Recuperar o objeto com o id
            //Alterar objeto com o objeto do parametro
            //Aplicar/Salvar objeto alterado na fonte de dados

            if (ModelState.IsValid)
            {
                if (Session["ListaPessoas"] != null)
                {
                    if (((List<Pessoa>)Session["ListaPessoas"])
                        .Where(p => p.Id == model.Id).Any())
                    {
                        var modelBase = ((List<Pessoa>)Session["ListaPessoas"])
                            .Where(p => p.Id == model.Id).FirstOrDefault();

                        //Atualiza seu registro com o model enviado por parametro...
                        ((List<Pessoa>)Session["ListaPessoas"])[model.Id - 1] = model;
                    }

                    var lista = (List<Pessoa>)Session["ListaPessoas"];
                    return View("List", lista);
                }
                else
                {
                    return View(new List<Pessoa>());
                }
            }
            else
            {
                return View("Create", model);
            }  
        }

        public ActionResult Delete(int id)
        {
            if (Session["ListaPessoas"] != null && id > 0)
            {
                if (((List<Pessoa>)Session["ListaPessoas"])
                    .Where(p => p.Id == id).Any())
                {
                    var modelBase = ((List<Pessoa>)Session["ListaPessoas"])
                        .Where(p => p.Id == id).FirstOrDefault();

                    var lista = ((List<Pessoa>)Session["ListaPessoas"]);
                    lista.Remove(modelBase);

                    Session["ListaPessoas"] = lista;
                    return View("List", lista);
                }
            }
            return View("List", new List<Pessoa>());
        }
	}
}