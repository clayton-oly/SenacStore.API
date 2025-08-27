using Microsoft.EntityFrameworkCore;
using SenacStore.API.Data;
using SenacStore.API.Interfaces;
using SenacStore.API.Models;

namespace SenacStore.API.Repositories
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly SenacStoreDbContext _context;

        public CadastroRepository(SenacStoreDbContext senacStoreDbContext)
        {
            _context = senacStoreDbContext;
        }

        public async Task<List<Cadastro>> GetAllAsync()
        {
            return await _context.Cadastros.ToListAsync();
        }

        public async Task<Cadastro> GetByIdAsync(int id)
        {
            return await _context.Cadastros.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Cadastro cadastro)
        {
            _context.Cadastros.Update(cadastro);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(Cadastro cadastro)
        {
            _context.Cadastros.Add(cadastro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro != null)
            {
                _context.Cadastros.Remove(cadastro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
