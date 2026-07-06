using Microsoft.EntityFrameworkCore;
using ProjetoSalaoDeBeleza.Data;
using ProjetoSalaoDeBeleza.Models;

namespace ProjetoSalaoDeBeleza.Services
{
    public class TransportadoresService
    {
        private readonly ApplicationDbContext _context;

        public TransportadoresService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transportadores>> GetTransportadoresAsync() =>
            await _context.Transportadores
                .AsNoTracking()
                .Include(t => t.oCidade)
                .ToListAsync();

        public async Task AddTransportadorAsync(Transportadores transportador)
        {
            transportador.Nome = transportador.Nome?.ToUpper() ?? string.Empty;
            transportador.CPF = transportador.CPF?.ToUpper();
            transportador.CNPJ = transportador.CNPJ?.ToUpper();
            transportador.Rua = transportador.Rua?.ToUpper();
            transportador.Bairro = transportador.Bairro?.ToUpper();
            transportador.Complemento = transportador.Complemento?.ToUpper();

            if (string.IsNullOrWhiteSpace(transportador.CPF) && string.IsNullOrWhiteSpace(transportador.CNPJ))
                throw new Exception("Informe CPF ou CNPJ.");

            if (!string.IsNullOrWhiteSpace(transportador.CPF) &&
                await _context.Transportadores.AnyAsync(t => t.CPF == transportador.CPF))
                throw new Exception("Já existe um transportador com este CPF.");

            if (!string.IsNullOrWhiteSpace(transportador.CNPJ) &&
                await _context.Transportadores.AnyAsync(t => t.CNPJ == transportador.CNPJ))
                throw new Exception("Já existe um transportador com este CNPJ.");

            if (!string.IsNullOrWhiteSpace(transportador.Email) &&
                await _context.Transportadores.AnyAsync(t => t.Email == transportador.Email))
                throw new Exception("Já existe um transportador com este e-mail.");

            transportador.oCidade = null;
            transportador.DataCadastro = DateTime.UtcNow;
            transportador.DataUltimaAlteracao = DateTime.UtcNow;
            transportador.UsuarioUltimaAlteracao = "sistema";

            _context.Transportadores.Add(transportador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTransportadorAsync(Transportadores transportador)
        {
            transportador.Nome = transportador.Nome?.ToUpper() ?? string.Empty;
            transportador.CPF = transportador.CPF?.ToUpper();
            transportador.CNPJ = transportador.CNPJ?.ToUpper();
            transportador.Rua = transportador.Rua?.ToUpper();
            transportador.Bairro = transportador.Bairro?.ToUpper();
            transportador.Complemento = transportador.Complemento?.ToUpper();

            if (string.IsNullOrWhiteSpace(transportador.CPF) && string.IsNullOrWhiteSpace(transportador.CNPJ))
                throw new Exception("Informe CPF ou CNPJ.");

            if (!string.IsNullOrWhiteSpace(transportador.CPF) &&
                await _context.Transportadores.AnyAsync(t => t.CPF == transportador.CPF
                    && t.CodTransportador != transportador.CodTransportador))
                throw new Exception("Já existe um transportador com este CPF.");

            if (!string.IsNullOrWhiteSpace(transportador.CNPJ) &&
                await _context.Transportadores.AnyAsync(t => t.CNPJ == transportador.CNPJ
                    && t.CodTransportador != transportador.CodTransportador))
                throw new Exception("Já existe um transportador com este CNPJ.");

            if (!string.IsNullOrWhiteSpace(transportador.Email) &&
                await _context.Transportadores.AnyAsync(t => t.Email == transportador.Email
                    && t.CodTransportador != transportador.CodTransportador))
                throw new Exception("Já existe um transportador com este e-mail.");

            var existente = await _context.Transportadores.FindAsync(transportador.CodTransportador);
            if (existente == null) throw new Exception("Transportador não encontrado.");

            existente.Nome = transportador.Nome;
            existente.CPF = transportador.CPF;
            existente.CNPJ = transportador.CNPJ;
            existente.Email = transportador.Email;
            existente.Telefone = transportador.Telefone;
            existente.CEP = transportador.CEP;
            existente.Rua = transportador.Rua;
            existente.Numero = transportador.Numero;
            existente.Complemento = transportador.Complemento;
            existente.Bairro = transportador.Bairro;
            existente.CodCidade = transportador.CodCidade;
            existente.Ativo = transportador.Ativo;
            existente.DataUltimaAlteracao = DateTime.UtcNow;
            existente.UsuarioUltimaAlteracao = "sistema";

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransportadorAsync(int id)
        {
            var temVeiculos = await _context.Veiculos.AnyAsync(v => v.CodTransportador == id);
            if (temVeiculos) throw new Exception("Não é possível excluir um transportador que possui veículos vinculados.");

            var transportador = await _context.Transportadores.FindAsync(id);
            if (transportador == null) throw new Exception("Transportador não encontrado.");

            _context.Transportadores.Remove(transportador);
            await _context.SaveChangesAsync();
        }
    }
}