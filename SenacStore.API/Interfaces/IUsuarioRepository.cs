using Microsoft.EntityFrameworkCore;
using SenacStore.API.Models;

namespace SenacStore.API.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario usuario);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task<Usuario> GetByLoginAsync(string email, string senha);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}
