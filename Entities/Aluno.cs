using System.Globalization;

namespace projetoIntegrador.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? SalaId { get; set; }
        public virtual Sala? Sala { get; set; }

    }
}
