using Microsoft.EntityFrameworkCore;
using ProjetoSalaoDeBeleza.Data;
using ProjetoSalaoDeBeleza.Models;

namespace ProjetoSalaoDeBeleza.Services
{
    public class FuncionariosService
    {
        private readonly ApplicationDbContext _dbContext;

        public FuncionariosService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Funcionarios>> GetFuncionariosAsync() =>
            await _dbContext.Funcionarios
                .AsNoTracking()
                .Include(f => f.oCidade)
                .ToListAsync();

        public async Task<Funcionarios> GetFuncionarioByIdAsync(int id) =>
            await _dbContext.Funcionarios.FindAsync(id);

        public async Task AddFuncionarioAsync(Funcionarios funcionario)
        {
            funcionario.Nome = funcionario.Nome?.ToUpper() ?? string.Empty;
            funcionario.CPF = funcionario.CPF?.ToUpper() ?? string.Empty;
            funcionario.Cargo = funcionario.Cargo?.ToUpper();
            funcionario.Logradouro = funcionario.Logradouro?.ToUpper();
            funcionario.Bairro = funcionario.Bairro?.ToUpper();
            funcionario.Complemento = funcionario.Complemento?.ToUpper();

            if (!string.IsNullOrWhiteSpace(funcionario.CPF) &&
                await _dbContext.Pessoas.AnyAsync(p => p.CPF == funcionario.CPF))
                throw new Exception("Já existe uma pessoa cadastrada com este CPF/CNPJ.");

            if (!string.IsNullOrWhiteSpace(funcionario.Email) &&
                await _dbContext.Pessoas.AnyAsync(p => p.Email == funcionario.Email))
                throw new Exception("Já existe uma pessoa cadastrada com este e-mail.");

            funcionario.oCidade = null;
            funcionario.DataCadastro = DateTime.UtcNow;
            funcionario.DataUltimaAlteracao = DateTime.UtcNow;
            funcionario.UsuarioUltimaAlteracao = "sistema";

            _dbContext.Funcionarios.Add(funcionario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateFuncionarioAsync(Funcionarios funcionario)
        {
            funcionario.Nome = funcionario.Nome?.ToUpper() ?? string.Empty;
            funcionario.CPF = funcionario.CPF?.ToUpper() ?? string.Empty;
            funcionario.Cargo = funcionario.Cargo?.ToUpper();
            funcionario.Logradouro = funcionario.Logradouro?.ToUpper();
            funcionario.Bairro = funcionario.Bairro?.ToUpper();
            funcionario.Complemento = funcionario.Complemento?.ToUpper();

            if (!string.IsNullOrWhiteSpace(funcionario.CPF) &&
                await _dbContext.Pessoas.AnyAsync(p => p.CPF == funcionario.CPF && p.CodPessoa != funcionario.CodPessoa))
                throw new Exception("Já existe uma pessoa cadastrada com este CPF/CNPJ.");

            if (!string.IsNullOrWhiteSpace(funcionario.Email) &&
                await _dbContext.Pessoas.AnyAsync(p => p.Email == funcionario.Email && p.CodPessoa != funcionario.CodPessoa))
                throw new Exception("Já existe uma pessoa cadastrada com este e-mail.");

            var existente = await _dbContext.Funcionarios.FindAsync(funcionario.CodPessoa);
            if (existente == null) throw new Exception("Funcionário não encontrado.");

            existente.Nome = funcionario.Nome;
            existente.CPF = funcionario.CPF;
            existente.Email = funcionario.Email;
            existente.Telefone = funcionario.Telefone;
            existente.DataNascimento = funcionario.DataNascimento;
            existente.CodCidade = funcionario.CodCidade;
            existente.Cargo = funcionario.Cargo;
            existente.Salario = funcionario.Salario;
            existente.DataAdmissao = funcionario.DataAdmissao;
            existente.DataDemissao = funcionario.DataDemissao;
            existente.ComissaoPercentual = funcionario.ComissaoPercentual;
            existente.Logradouro = funcionario.Logradouro;
            existente.Bairro = funcionario.Bairro;
            existente.Complemento = funcionario.Complemento;
            existente.Numero = funcionario.Numero;
            existente.CEP = funcionario.CEP;
            existente.Ativo = funcionario.Ativo;
            existente.PessoaJuridica = funcionario.PessoaJuridica;
            existente.DataUltimaAlteracao = DateTime.UtcNow;
            existente.UsuarioUltimaAlteracao = "sistema";

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFuncionarioAsync(int id)
        {
            var funcionario = await _dbContext.Funcionarios.FindAsync(id);
            if (funcionario == null) throw new Exception("Funcionário não encontrado.");

            _dbContext.Funcionarios.Remove(funcionario);
            await _dbContext.SaveChangesAsync();
        }
    }
}