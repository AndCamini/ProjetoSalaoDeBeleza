using Microsoft.EntityFrameworkCore;
using ProjetoSalaoDeBeleza.Data;
using ProjetoSalaoDeBeleza.Models;

namespace ProjetoSalaoDeBeleza.Services
{
    public class ProdutosService
    {
        private readonly ApplicationDbContext _context;

        public ProdutosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produtos>> GetProdutosAsync() =>
            await _context.Produtos
                .AsNoTracking()
                .Include(p => p.oCategoria)
                .ToListAsync();

        public async Task AddProdutoAsync(Produtos produto)
        {
            produto.Produto = produto.Produto?.ToUpper() ?? string.Empty;
            produto.Descricao = produto.Descricao?.ToUpper();
            produto.UnidadeMedida = produto.UnidadeMedida?.ToUpper() ?? string.Empty;

            Validar(produto);

            var duplicado = await _context.Produtos
                .AnyAsync(p => p.Produto == produto.Produto);
            if (duplicado) throw new Exception("Já existe um produto com esse nome.");

            produto.oCategoria = null;
            produto.DataCadastro = DateTime.UtcNow;
            produto.DataUltimaAlteracao = DateTime.UtcNow;
            produto.UsuarioUltimaAlteracao = "sistema";

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProdutoAsync(Produtos produto)
        {
            produto.Produto = produto.Produto?.ToUpper() ?? string.Empty;
            produto.Descricao = produto.Descricao?.ToUpper();
            produto.UnidadeMedida = produto.UnidadeMedida?.ToUpper() ?? string.Empty;

            Validar(produto);

            var duplicado = await _context.Produtos
                .AnyAsync(p => p.Produto == produto.Produto && p.CodProduto != produto.CodProduto);
            if (duplicado) throw new Exception("Já existe um produto com esse nome.");

            var existente = await _context.Produtos.FindAsync(produto.CodProduto);
            if (existente == null) throw new Exception("Produto não encontrado.");

            existente.Produto = produto.Produto;
            existente.Descricao = produto.Descricao;
            existente.PrecoVenda = produto.PrecoVenda;
            existente.UnidadeMedida = produto.UnidadeMedida;
            existente.Ativo = produto.Ativo;
            existente.CodCategoria = produto.CodCategoria;
            existente.DataUltimaAlteracao = DateTime.UtcNow;
            existente.UsuarioUltimaAlteracao = "sistema";

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProdutoAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) throw new Exception("Produto não encontrado.");

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        private void Validar(Produtos produto)
        {
            if (produto.PrecoVenda < produto.PrecoCusto)
                throw new Exception("Preço de venda não pode ser menor que o preço de custo.");

            if (produto.CodCategoria == 0)
                throw new Exception("Selecione uma categoria.");
        }
    }
}