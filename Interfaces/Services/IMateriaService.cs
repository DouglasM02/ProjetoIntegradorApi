using projetoIntegrador.Entities;
using projetoIntegrador.Models.Aluno;
using projetoIntegrador.Models.Materia;

namespace projetoIntegrador.Interfaces.Services
{
    public interface IMateriaService
    {
        public Task<Materia> Create(MateriaModel materia);
        public Task<Materia> Update(MateriaUpdateModel materia);
        public Task<Materia> GetById(int id);
        public Task<List<Materia>> GetAll();
        public Task<Boolean> Delete(int id);
    }
}
