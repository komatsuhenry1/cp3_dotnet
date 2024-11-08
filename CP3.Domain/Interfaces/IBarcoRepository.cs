using CP3.Domain.Entities;
using System.Collections.Generic;

namespace CP3.Domain.Interfaces
{
    public interface IBarcoRepository
    {
        IEnumerable<BarcoEntity> ObterTodos();
        BarcoEntity ObterPorId(int id);
        BarcoEntity Adicionar(BarcoEntity barco);
        BarcoEntity Editar(BarcoEntity barco);
        BarcoEntity Remover(int id);
    }
}
