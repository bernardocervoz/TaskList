using TaskList.Domain.Interfaces.Repositories;
using TaskList.Domain.Models.Entities;
using TaskList.Infrastructure.DataContexts;
using System.Linq;
using System.Collections.Generic;

namespace TaskList.Infrastructure.Repositories
{
    /// <summary>
    ///Implementação da interface de repositório das tarefas responsável pelas interações entre o banco de dados.
    /// </summary>
    public class TaskManagerRepository : RepositoryBase<TaskManager>, ITaskManagerRepository
    {
        /// <summary>
        /// Contrutor da classe com os parametros que serão injetados automaticamente.
        /// </summary>
        /// <param name="db">Contexto do banco de dados</param>
        public TaskManagerRepository(TaskListContext db)
            : base(db)
        {
            this._db = db;
        }

        /// <summary>
        /// Implementação do método que busca todas as tarefas ativas no banco de dados 
        /// </summary>
        /// <param name="skip">Variavel para paginação</param>
        /// <param name="take">Variavel para paginação</param>
        /// <param name="count">Quantidade de registros</param>
        /// <returns>retorna uma lista de tarefas</returns>
        public List<TaskManager> GetTaskManagers(int skip, int take, out int count)
        {
            var query = _db.TaskManagers
                    .Where(x => !x.Deleted)
                    .AsQueryable();
            count = query.Count();
            query = query.OrderBy(x => x.Id);
            query = SkipQuery(query, skip);
            query = TakeQuery(query, take);
            return query.ToList();
        }
    }
}
