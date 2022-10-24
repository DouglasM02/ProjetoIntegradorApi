namespace projetoIntegrador.Entities
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? ProfessorId { get; set; }
        public virtual Professor? Professor { get; set; }
    }
}
