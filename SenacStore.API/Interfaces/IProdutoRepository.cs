using SenacStore.API.Models;

namespace SenacStore.API.Interfaces
{
    public interface IProdutoRepository
    {
        Task AddAsync(Produto produto);
        Task<List<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(int id);
        Task<List<Produto>> GetByCategoryAsync(int categoryId);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(int id);
    }
}
