namespace projetoIntegrador.Entities
{
    public class Sala
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public virtual List<Aluno>? Alunos { get; set; }
    }
}
