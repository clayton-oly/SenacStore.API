
using SenacStore.API.Models;

namespace SenacStore.API.Interfaces
{
    public interface ICategoriaRepository
    {
        Task AddAsync(Categoria categoria);
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria> GetByIdAsync(int id);

        Task UpdateAsync(Categoria categoria);
        Task DeleteAsync(int id);
    }
}
