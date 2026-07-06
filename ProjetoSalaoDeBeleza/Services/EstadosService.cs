using Microsoft.EntityFrameworkCore;
using ProjetoSalaoDeBeleza.Data;
using ProjetoSalaoDeBeleza.Models;

namespace ProjetoSalaoDeBeleza.Services
{
    public class EstadosService
    {
        private readonly ApplicationDbContext _context;

        public EstadosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estados>> GetEstadosAsync() =>
            await _context.Estados.Include(e => e.oPais).ToListAsync();

        public async Task<Estados> GetEstadoByIdAsync(int id) =>
            await _context.Estados.FindAsync(id);

        public async Task AddEstadoAsync(Estados estado)
        {
            estado.Estado = estado.Estado?.ToUpper() ?? string.Empty;
            estado.UF = estado.UF?.ToUpper() ?? string.Empty;

            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEstadoAsync(Estados estado)
        {
            var existente = await _context.Estados.FindAsync(estado.CodEstado);
            if (existente == null) throw new Exception("Estado não encontrado.");

            existente.Estado = estado.Estado?.ToUpper() ?? string.Empty;
            existente.UF = estado.UF?.ToUpper() ?? string.Empty;
            existente.CodPais = estado.CodPais;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstadoAsync(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null) throw new Exception("Estado não encontrado.");

            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();
        }
    }
}