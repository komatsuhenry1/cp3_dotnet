using CP3.Domain.Interfaces.Dtos;

namespace CP3.Application.Dtos
{
    public class BarcoDto : IBarcoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public double Tamanho { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(Nome) &&
                   !string.IsNullOrEmpty(Modelo) &&
                   Ano > 0 &&
                   Tamanho > 0;
        }
    }
}
