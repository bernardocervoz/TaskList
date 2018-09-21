using System;

namespace TaskList.Domain.Models.Entities
{

    public partial class BloqueioEdicao
    {
        public int IDBloqueioEdicao { get; set; }

        public int IdUsuario { get; set; }

        public int IdRegistro { get; set; }

        public string Pagina { get; set; }

        public DateTime DataBloqueio { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
