using Microsoft.EntityFrameworkCore;
using ProjetoSalaoDeBeleza.Data;
using ProjetoSalaoDeBeleza.Models;

namespace ProjetoSalaoDeBeleza.Services
{
    public class PaisesService
    {
        private readonly ApplicationDbContext _context;

        public PaisesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Paises>> GetPaisesAsync() => await _context.Paises.ToListAsync();

        public async Task<Paises> GetPaisByIdAsync(int id) => await _context.Paises.FindAsync(id);

        public async Task AddPaisAsync(Paises pais)
        {
            pais.Pais = pais.Pais?.ToUpper() ?? string.Empty;
            pais.Sigla = pais.Sigla?.ToUpper() ?? string.Empty;
            pais.DDI = pais.DDI?.ToUpper() ?? string.Empty;
            pais.Moeda = pais.Moeda?.ToUpper() ?? string.Empty;

            _context.Paises.Add(pais);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaisAsync(Paises pais)
        {
            var existente = await _context.Paises.FindAsync(pais.CodPais);
            if (existente == null) throw new Exception("País não encontrado.");

            existente.Pais = pais.Pais?.ToUpper() ?? string.Empty;
            existente.Sigla = pais.Sigla?.ToUpper() ?? string.Empty;
            existente.DDI = pais.DDI?.ToUpper() ?? string.Empty;
            existente.Moeda = pais.Moeda?.ToUpper() ?? string.Empty;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePaisAsync(int id)
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais != null)
            {
                _context.Paises.Remove(pais);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("País não encontrado.");
            }
        }
    }
}