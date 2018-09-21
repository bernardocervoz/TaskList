using TaskList.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Domain.Interfaces.Repositories
{
    public interface IBloqueioEdicaoRepository: IRepositoryBase<BloqueioEdicao>
    {
        bool RegistroBloqueado(int idRegistro, string NomePagina);
    }
}
