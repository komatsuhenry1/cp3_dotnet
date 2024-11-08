using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using CP3.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace CP3.Application.Services
{
    public class BarcoApplicationService : IBarcoApplicationService
    {
        private readonly IBarcoRepository _repository;

        public BarcoApplicationService(IBarcoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BarcoEntity> ObterTodosBarcos() => _repository.ObterTodos();

        public BarcoEntity ObterBarcoPorId(int id) => _repository.ObterPorId(id);

        public BarcoEntity AdicionarBarco(IBarcoDto dto)
        {
            var barco = new BarcoEntity
            {
                Nome = dto.Nome,
                Modelo = dto.Modelo,
                Ano = dto.Ano,
                Tamanho = dto.Tamanho
            };

            return _repository.Adicionar(barco);
        }

        public BarcoEntity EditarBarco(int id, IBarcoDto dto)
        {
            var barco = _repository.ObterPorId(id);
            if (barco == null) return null;

            barco.Nome = dto.Nome;
            barco.Modelo = dto.Modelo;
            barco.Ano = dto.Ano;
            barco.Tamanho = dto.Tamanho;

            return _repository.Editar(barco);
        }

        public BarcoEntity RemoverBarco(int id) => _repository.Remover(id);
    }
}
