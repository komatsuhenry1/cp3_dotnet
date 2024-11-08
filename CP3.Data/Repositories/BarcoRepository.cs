using CP3.Data.AppData;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CP3.Data.Repositories
{
    public class BarcoRepository : IBarcoRepository
    {
        private readonly ApplicationContext _context;

        public BarcoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public BarcoEntity? ObterPorId(int id) => _context.Barco.Find(id);

        public IEnumerable<BarcoEntity>? ObterTodos() => _context.Barco.ToList();

        public BarcoEntity? Adicionar(BarcoEntity barco)
        {
            _context.Barco.Add(barco);
            _context.SaveChanges();
            return barco;
        }

        public BarcoEntity? Editar(BarcoEntity barco)
        {
            _context.Barco.Update(barco);
            _context.SaveChanges();
            return barco;
        }

        public BarcoEntity? Remover(int id)
        {
            var barco = _context.Barco.Find(id);
            if (barco == null) return null;

            _context.Barco.Remove(barco);
            _context.SaveChanges();
            return barco;
        }
    }
}
