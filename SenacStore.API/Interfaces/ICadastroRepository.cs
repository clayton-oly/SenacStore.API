using SenacStore.API.Models;

namespace SenacStore.API.Interfaces
{
    public interface ICadastroRepository
    {
        Task AddAsync(Cadastro cadastro);
        Task<List<Cadastro>> GetAllAsync();
        Task<Cadastro> GetByIdAsync(int id);
        Task UpdateAsync(Cadastro cadastro);
        Task DeleteAsync(int id);
    }
}
