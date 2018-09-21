using System.ComponentModel;

namespace TaskList.Domain.Commons.Enums
{
    public enum StatusTask
    {
        [Description("Criada")]
        Created = 1,
        [Description("Em execução")]
        Running = 2,
        [Description("Concluída")]
        Completed = 3,
        [Description("Cancelada")]
        Canceled = 4
    }
}
