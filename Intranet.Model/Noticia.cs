using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Model
{
    /// <summary>
    /// Entidade responsável por representar os dados de uma Notícia.
    /// </summary>
    public class Noticia
    {
        #region Propriedades

        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public DateTime DataPostagem { get; set; }
        public virtual ICollection<Departamento> DepartamentoList { get; set; }

        #endregion

        #region Construtor

        public Noticia()
        {
            this.DepartamentoList = new List<Departamento>();
        }

        #endregion
    }
}
