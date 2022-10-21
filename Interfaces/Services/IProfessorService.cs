using projetoIntegrador.Entities;
using projetoIntegrador.Models.Aluno;
using projetoIntegrador.Models.Professor;

namespace projetoIntegrador.Interfaces.Services
{
    public interface IProfessorService
    {
        public Task<Entities.Professor> Create(ProfessorModel aluno);
        public Task<Entities.Professor> Update(ProfessorUpdateModel aluno);
        public Task<Entities.Professor> GetById(int id);
        public Task<List<Entities.Professor>> GetAll();
        public Task<Boolean> Delete(int id);
    }
}
