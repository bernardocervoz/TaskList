using TaskList.Domain.Interfaces.Repositories;
using TaskList.Infrastructure.DataContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TaskList.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected TaskListContext _db;

        /// <summary>
        /// Contrutor da classe com os parametros que serão injetados automaticamente.
        /// </summary>
        /// <param name="db">Contexto do banco de dados</param>
        public RepositoryBase(TaskListContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Implementação do método que adiciona um registro.
        /// </summary>
        /// <param name="obj">Classe que esta sendo inserido o registro.</param>
        public void Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            _db.SaveChanges();
        }

        /// <summary>
        /// Implementação do método que adiciona uma lista de registros.
        /// </summary>
        /// <param name="obj">Lista da classe que esta sendo inserido os registros.</param>
        public void AddList(IEnumerable<TEntity> obj)
        {
            foreach (var item in obj)
            {
                _db.Set<TEntity>().Add(item);
            }
                _db.SaveChanges();
        }
        
        /// <summary>
        /// Implementação do método que altera um registro.
        /// </summary>
        /// <param name="obj">Classe que esta sendo alterado o registro.</param>
        public void Update(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
        }

        /// <summary>
        /// Implementação do método que altera uma lista de registros.
        /// </summary>
        /// <param name="obj">lista da classe que esta sendo alterado os registros.</param>
        public void UpdateList(IEnumerable<TEntity> obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
        }

        /// <summary>
        /// Implementação do método que exclui um registro.
        /// </summary>
        /// <param name="obj">Classe que esta sendo excluido o registro.</param>
        public void Remove(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
            _db.SaveChanges();
        }

        /// <summary>
        /// Implementação do método que busca um registro pelo Id.
        /// </summary>
        /// <param name="id">Id do registro</param>
        /// <returns>Retorna um objeto com o registro.</returns>
        public TEntity GetById(long id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Implementação do método que busca todos os registros de uma determinada classe.
        /// </summary>
        /// <returns>Retorna uma lista de uma determinada classe.</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Implementação do método que busca todos os registros de uma determinada classe, sem armazenar na cache do EF.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAllAsNoTracking()
        {
            return _db.Set<TEntity>().AsNoTracking().ToList();
        }

        /// <summary>
        /// Implementação do método que busca todos os registros de uma determinada classe.
        /// </summary>
        /// <returns>retorna uma consulta que ainda não foi executada no BD</returns>
        public virtual IQueryable<TEntity> GetList()
        {
            return _db.Set<TEntity>().AsNoTracking();
        }

        /// <summary>
        /// Implementação do método que realiza o skip em uma consulta, utilizado em paginação.
        /// </summary>
        /// <param name="query">Consulta</param>
        /// <param name="skip">Quantidade do skip</param>
        /// <returns>retorna uma consulta que ainda não foi executada no BD</returns>
        public IQueryable<TEntity> SkipQuery(IQueryable<TEntity> query, int? skip)
        {
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            return query;
        }

        /// <summary>
        /// Implementação do método que realiza o take em uma consulta, utilizado em paginação.
        /// </summary>
        /// <param name="query">Consulta</param>
        /// <param name="take">Quantidade do Take</param>
        /// <returns>retorna uma consulta que ainda não foi executada no BD</returns>
        public IQueryable<TEntity> TakeQuery(IQueryable<TEntity> query, int? take)
        {
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        #region Dispose
        /// <summary>
        /// Implementação do método que libera recursos da memória.
        /// </summary>
        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }
        #endregion
    }
}
