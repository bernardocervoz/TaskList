using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Domain.Interfaces.Repositories
{
    /// <summary>
    ///Interface da classe de repositório genérica responsável pelas interações genéricas entre o banco de dados.
    /// </summary>
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Assinatura do método que adiciona um registro.
        /// </summary>
        /// <param name="obj">Classe que esta sendo inserido o registro.</param>
        void Add(TEntity obj);

        /// <summary>
        /// Assinatura do método que adiciona uma lista de registros.
        /// </summary>
        /// <param name="obj">Lista da classe que esta sendo inserido os registros.</param>
        void AddList(IEnumerable<TEntity> obj);

        /// <summary>
        /// Assinatura do método que altera um registro.
        /// </summary>
        /// <param name="obj">Classe que esta sendo alterado o registro.</param>
        void Update(TEntity obj);

        /// <summary>
        /// Assinatura do método que altera uma lista de registros.
        /// </summary>
        /// <param name="obj">Lista da classe que esta sendo alterado os registros.</param>
        void UpdateList(IEnumerable<TEntity> obj);

        /// <summary>
        /// Assinatura do método que exclui um registro.
        /// </summary>
        /// <param name="obj">Classe que esta sendo excluido o registro.</param>
        void Remove(TEntity obj);

        /// <summary>
        /// Assinatura do método que busca um registro pelo Id.
        /// </summary>
        /// <param name="id">Id do registro</param>
        /// <returns>Retorna um objeto com o registro.</returns>
        TEntity GetById(long id);

        /// <summary>
        /// Assinatura do método que busca todos os registros de uma determinada classe.
        /// </summary>
        /// <returns>Retorna uma lista de uma determinada classe.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Assinatura do método que busca todos os registros de uma determinada classe, sem armazenar na cache do EF.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllAsNoTracking();
        /// <summary>
        /// Assinatura do método que busca todos os registros de uma determinada classe.
        /// </summary>
        /// <returns>retorna uma consulta que ainda não foi executada no BD</returns>
        IQueryable<TEntity> GetList();

        /// <summary>
        /// Assinatura do método que realiza o skip em uma consulta, utilizado em paginação.
        /// </summary>
        /// <param name="query">Consulta</param>
        /// <param name="skip">Quantidade do skip</param>
        /// <returns>retorna uma consulta que ainda não foi executada no BD</returns>
        IQueryable<TEntity> SkipQuery(IQueryable<TEntity> query, int? skip);

        /// <summary>
        /// Assinatura do método que realiza o take em uma consulta, utilizado em paginação.
        /// </summary>
        /// <param name="query">Consulta</param>
        /// <param name="take">Quantidade do Take</param>
        /// <returns>retorna uma consulta que ainda não foi executada no BD</returns>
        IQueryable<TEntity> TakeQuery(IQueryable<TEntity> query, int? take);

        /// <summary>
        /// Assinatura do método que libera recursos da memória.
        /// </summary>
        void Dispose();
    }
}
