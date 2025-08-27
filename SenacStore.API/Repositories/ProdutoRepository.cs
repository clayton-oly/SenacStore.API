using Microsoft.EntityFrameworkCore;
using SenacStore.API.Data;
using SenacStore.API.Interfaces;
using SenacStore.API.Models;

namespace SenacStore.API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SenacStoreDbContext _context;

        public ProdutoRepository(SenacStoreDbContext senacStoreDbContext)
        {
            _context = senacStoreDbContext;
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            return await _context.Produtos.Include(p => p.Categoria).ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            return await _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
