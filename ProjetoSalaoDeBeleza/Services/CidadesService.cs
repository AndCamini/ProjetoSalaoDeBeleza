using Microsoft.EntityFrameworkCore;
using ProjetoSalaoDeBeleza.Data;
using ProjetoSalaoDeBeleza.Models;

namespace ProjetoSalaoDeBeleza.Services
{
    public class CidadesService
    {
        private readonly ApplicationDbContext _context;
        public CidadesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cidades>> GetCidadesAsync() => await _context.Cidades.Include(e => e.oEstado).ToListAsync();
        public async Task<Cidades> GetCidadeByIdAsync(int id) => await _context.Cidades.FindAsync(id);
        public async Task AddCidadeAsync(Cidades cidade)
        {
            _context.Cidades.Add(cidade);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCidadeAsync(Cidades cidade)
        {
            _context.Cidades.Update(cidade);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCidadeAsync(int id)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade != null)
            {
                _context.Cidades.Remove(cidade);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Cidade não encontrada.");
            }
        }
    }
}
