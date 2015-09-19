using Intranet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Intranet.Presentation.Models
{
    /// <summary>
    /// Model para a página de cadastro de notícias
    /// </summary>
    public class CadastroNoticiasViewModel
    {
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Departamento { get; set; }

        public List<Departamento> DepartamentoList { get; set; }
    }

    /// <summary>
    /// Model para a página que lista todas as notícias disponíveis
    /// </summary>
    public class IndexNoticiasViewModel
    {
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Display(Name = "Data de Publicação")]
        public DateTime DataPublicacao { get; set; }
        [Display(Name = "Departamento(s)")]
        public string Departamento { get; set; }
        public List<Noticia> NoticiaList { get; set; }
    }
}