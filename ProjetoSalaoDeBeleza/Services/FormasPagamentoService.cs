using Microsoft.EntityFrameworkCore;
using ProjetoSalaoDeBeleza.Data;
using ProjetoSalaoDeBeleza.Models;

namespace ProjetoSalaoDeBeleza.Services
{
    public class FormasPagamentoService
    {
        private readonly ApplicationDbContext _context;

        public FormasPagamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FormasPagamento>> GetFormasPagamentoAsync() =>
            await _context.FormasPagamento.AsNoTracking().ToListAsync();

        public async Task AddFormaPagamentoAsync(FormasPagamento forma)
        {
            var duplicada = await _context.FormasPagamento
                .AnyAsync(f => f.FormaPagamento.ToLower() == forma.FormaPagamento.ToLower());
            if (duplicada) throw new Exception("Já existe uma forma de pagamento com essa descrição.");

            _context.FormasPagamento.Add(forma);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFormaPagamentoAsync(FormasPagamento forma)
        {
            var duplicada = await _context.FormasPagamento
                .AnyAsync(f => f.FormaPagamento.ToLower() == forma.FormaPagamento.ToLower()
                            && f.CodFormaPagamento != forma.CodFormaPagamento);
            if (duplicada) throw new Exception("Já existe uma forma de pagamento com essa descrição.");

            var existente = await _context.FormasPagamento.FindAsync(forma.CodFormaPagamento);
            if (existente == null) throw new Exception("Forma de pagamento não encontrada.");

            existente.FormaPagamento = forma.FormaPagamento;
            existente.Ativo = forma.Ativo;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteFormaPagamentoAsync(int id)
        {
            var forma = await _context.FormasPagamento.FindAsync(id);
            if (forma == null) throw new Exception("Forma de pagamento não encontrada.");

            _context.FormasPagamento.Remove(forma);
            await _context.SaveChangesAsync();
        }
    }
}