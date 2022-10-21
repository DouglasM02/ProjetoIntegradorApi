using projetoIntegrador.Entities;
using projetoIntegrador.Models.Aluno;
using projetoIntegrador.Models.Sala;

namespace projetoIntegrador.Interfaces.Services
{
    public interface ISalaService
    {
        public Task<Sala> Create(SalaModel aluno);
        public Task<Sala> Update(SalaUpdateModel aluno);
        public Task<Sala> GetById(int id);
        public Task<List<Sala>> GetAll();
        public Task<Boolean> Delete(int id);
    }
}
