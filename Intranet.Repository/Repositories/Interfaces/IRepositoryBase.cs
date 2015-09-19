using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Repository.Repositories.Interfaces
{
    /// <summary>
    /// Interface de Repositório Genérica.
    /// </summary>
    /// <typeparam name="T">Tipo Genérico da Entidade.</typeparam>
    public interface IRepositoryBase<T>
        where T : class
    {
        void Insert(T obj);
        void Delete(T obj);
        void Update(T obj);
        ICollection<T> FindAll();
        T FindById(int id);
    }
}
