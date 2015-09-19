using Intranet.Data.Context;
using Intranet.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Repository.Repositories
{
    /// <summary>
    /// Classe para implementação do repositório genérico.
    /// </summary>
    /// <typeparam name="T">Genérico que representa a entidade.</typeparam>
    public abstract class RepositoryBase<T> : IDisposable, IRepositoryBase<T>
        where T : class
    {
        /// <summary>
        /// atributo para a classe de contexto com o banco de dados.
        /// </summary>
        protected DataContext context;

        public DataContext Context { get; set; }

        #region Construtor
        /// <summary>
        /// Construtor Default.
        /// </summary>
        public RepositoryBase()
        {
            //inicializando o contexto...
            this.context = new DataContext();
        }

        #endregion

        #region Métodos para manipulação de dados

        /// <summary>
        /// Método responsável por inserir os registros de uma entidade no banco de dados.
        /// </summary>
        /// <param name="obj">Entidade a ser inserida no banco de dados.</param>
        public void Insert(T obj)
        {
            //adicionando
            context.Entry(obj).State = EntityState.Added;
            //salvando modificações
            context.SaveChanges();
        }

        /// <summary>
        /// Métodos responsável por remover os dados de uma entidade do banco de dados.
        /// </summary>
        /// <param name="obj">Entidade a ser removida da base de dados.</param>
        public void Delete(T obj)
        {
            //removendo
            context.Entry(obj).State = EntityState.Deleted;
            //salvando alterações
            context.SaveChanges();
        }

        /// <summary>
        /// Método responsável pela atualização das informações de uma entidade.
        /// </summary>
        /// <param name="obj">Entidade a ser atualizada.</param>
        public void Update(T obj)
        {
            //realizando update.
            context.Entry(obj).State = EntityState.Modified;
            //salvando alterações na base ...
            context.SaveChanges();
        }

        /// <summary>
        /// Método para retornar todas as entidades
        /// </summary>
        /// <returns>Lista com todas as entidades.</returns>
        public ICollection<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        /// <summary>
        /// Método para retornar uma entidade a partir de seu identificador
        /// </summary>
        /// <param name="id">Identificador da instance</param>
        /// <returns>Instância completa de uma entidade.</returns>
        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        #endregion

        #region Implementação do Dispose

        public void Dispose()
        {
            context.Dispose();
        }

        #endregion
    }
}
