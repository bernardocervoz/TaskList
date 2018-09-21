using System.Collections.Generic;
using TaskList.Domain.Models.Entities;

namespace TaskList.Domain.Interfaces.Repositories
{
    /// <summary>
    ///Interface de repositório das tarefas responsável pelas interações entre o banco de dados.
    /// </summary>
    public interface ITaskManagerRepository : IRepositoryBase<TaskManager>
    {
        /// <summary>
        /// Assinatura do método que busca todas as tarefas ativas no banco de dados 
        /// </summary>
        /// <param name="skip">Variavel para paginação</param>
        /// <param name="take">Variavel para paginação</param>
        /// <param name="count">Quantidade de registros</param>
        /// <returns>retorna uma lista de tarefas</returns>
        List<TaskManager> GetTaskManagers(int skip, int take, out int count);
    }
}
