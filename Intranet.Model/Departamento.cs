using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Model
{
    /// <summary>
    /// Entidade responsável por representar os dados de um Departamento.
    /// </summary>
    public class Departamento
    {
        #region  Propriedades

        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public virtual ICollection<Noticia> NoticiaList { get; set; }

        #endregion

        #region Construtor

        public Departamento()
        {
            this.NoticiaList = new List<Noticia>();
        }

        #endregion
    }
}
