using System.Collections.Generic;
using TaskList.Domain.Interfaces.UnitOfWork;
using TaskList.Domain.Models.Entities;
using TaskList.Service.Interfaces.Services;

namespace TaskList.Service.Services.DomainLayer
{
    /// <summary>
    ///Implementação da interface de tarefas responsável pelas regras de negócio relacionadas as tarefas.
    /// </summary>
    public class TaskManagerService : ServiceBase<TaskManager>, ITaskManagerService
    {
        /// <summary>
        /// Contrutor da classe com os parametros que serão injetados automaticamente.
        /// </summary>
        /// <param name="session"> Ingeção de dependencias</param>
        public TaskManagerService(IUnitOfWork session)
            : base(session.TaskManagerRepository, session)
        {

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
            return Session.TaskManagerRepository.GetTaskManagers(skip, take, out count);
        }
    }
}