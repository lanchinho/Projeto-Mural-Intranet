using Intranet.Data.Context; //não era para isso aqui estar aqui ...
using Intranet.Model;
using Intranet.Presentation.Models;
using Intranet.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intranet.Presentation.Controllers
{
    public class NoticiaController : Controller
    {
        #region Propriedades
        #endregion

        #region Construtor

        public NoticiaController()
        {
        }

        #endregion

        /// <summary>
        /// Action para renderizar a página inicial do projeto.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IndexNoticiasViewModel model = new IndexNoticiasViewModel();
            NoticiaRepository _noticiaRepository = new NoticiaRepository();

            model.NoticiaList = _noticiaRepository.FindAll().ToList();

            return View(model);
        }

        /// <summary>
        ///Action para "renderizar" a view de cadastro. 
        /// </summary>
        public ActionResult Create()
        {
            LoadMultiSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarNoticia(CadastroNoticiasViewModel model, int[] idDepartamento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DataContext contexto = new DataContext();
                    Noticia noticia = new Noticia()
                    {
                        Titulo = model.Titulo,
                        Corpo = model.Corpo,
                        DataPostagem = DateTime.Now,
                    };

                    for (int i = 0; i < idDepartamento.Length; i++)
                    {
                        int idDepto = idDepartamento[i];
                        Departamento depto = contexto.Departamento.Single(d => d.IdDepartamento == idDepto);
                        noticia.DepartamentoList.Add(depto);
                        //using (DepartamentoRepository _deptoRepository = new DepartamentoRepository())
                        //{
                        //    noticia.DepartamentoList.Add(_deptoRepository.FindById(idDepartamento[i]));
                        //}
                    }

                    //using (NoticiaRepository noticiaRepository = new NoticiaRepository())
                    //{
                    //    noticiaRepository.Insert(noticia);
                    //}

                    contexto.Noticia.Add(noticia);
                    contexto.SaveChanges();
                    contexto.Dispose();

                    ViewBag.Mensagem = "Noticia Cadastrada com Sucesso";

                    ModelState.Clear();
                    LoadMultiSelectList();
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View("Create");

        }

        #region Métodos Auxiliares

        /// <summary>
        /// Método para carregar a Dropdown de seleção múltipla.
        /// </summary>
        private void LoadMultiSelectList()
        {
            using (DepartamentoRepository _deptoRepository = new DepartamentoRepository())
            {
                List<Departamento> departamentos = _deptoRepository.FindAll().ToList();
                ViewBag.Departamentos = new MultiSelectList(departamentos, "IdDepartamento", "Nome");
            }
        }

        #endregion
    }
}