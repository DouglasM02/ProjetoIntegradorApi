namespace projetoIntegrador.Entities
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Graduacao { get; set; }
        public virtual Materia? Materia { get; set; }
        public virtual Sala? Sala { get; set; }
    }
}
