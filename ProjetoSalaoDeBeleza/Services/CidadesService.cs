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

        public async Task<List<Cidades>> GetCidadesAsync() =>
            await _context.Cidades.Include(e => e.oEstado).ToListAsync();

        public async Task<Cidades> GetCidadeByIdAsync(int id) =>
            await _context.Cidades.FindAsync(id);

        public async Task AddCidadeAsync(Cidades cidade)
        {
            cidade.Cidade = cidade.Cidade?.ToUpper() ?? string.Empty;

            if (await _context.Cidades.AnyAsync(c => c.Cidade == cidade.Cidade && c.CodEstado == cidade.CodEstado))
                throw new Exception("Já existe uma cidade com esse nome neste estado.");

            cidade.DataCadastro = DateTime.UtcNow;
            cidade.DataUltimaAlteracao = DateTime.UtcNow;
            cidade.UsuarioUltimaAlteracao = "sistema";

            _context.Cidades.Add(cidade);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCidadeAsync(Cidades cidade)
        {
            cidade.Cidade = cidade.Cidade?.ToUpper() ?? string.Empty;

            if (await _context.Cidades.AnyAsync(c => c.Cidade == cidade.Cidade && c.CodEstado == cidade.CodEstado && c.CodCidade != cidade.CodCidade))
                throw new Exception("Já existe uma cidade com esse nome neste estado.");

            var existente = await _context.Cidades.FindAsync(cidade.CodCidade);
            if (existente == null) throw new Exception("Cidade não encontrada.");

            existente.Cidade = cidade.Cidade;
            existente.CodEstado = cidade.CodEstado;
            existente.DDD = cidade.DDD;
            existente.DataUltimaAlteracao = DateTime.UtcNow;
            existente.UsuarioUltimaAlteracao = "sistema";

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCidadeAsync(int id)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null) throw new Exception("Cidade não encontrada.");

            _context.Cidades.Remove(cidade);
            await _context.SaveChangesAsync();
        }
    }
}