using Microsoft.EntityFrameworkCore;
using SenacStore.API.Data;
using SenacStore.API.Interfaces;
using SenacStore.API.Models;

namespace SenacStore.API.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SenacStoreDbContext _context;

        public CategoriaRepository(SenacStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}
