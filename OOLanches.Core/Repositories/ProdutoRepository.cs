using Microsoft.EntityFrameworkCore;
using OOLanches.Core.Context;
using OOLanches.Core.Entities;
using OOLanches.Core.Interfaces;

namespace OOLanches.Core.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _dbContext;

        public ProdutoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Ao utilizar AsNoTracking, o Entity Framework não acompanha as modificações feitas
        // nos objetos recuperados. Isso significa que o contexto não precisa gerar entradas
        // no gráfico de objetos e não precisa rastrear as entidades para detectar alterações.
        // A desativação do rastreamento pode resultar em um ganho de desempenho considerável,
        // especialmente em consultas complexas ou quando se recupera um grande número de entidades.
        public async Task<IEnumerable<Produto>> ObterProdutosPorCategoriaAsync(int categoriaId)
        {
            return await _dbContext.Produtos
                .Where(p => p.CategoriaId == categoriaId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPopularesAsync()
        {
            return await _dbContext.Produtos.AsNoTracking()
                .Where(p => p.Popular)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosMaisVendidosAsync()
        {
            return await _dbContext.Produtos.AsNoTracking()
                .Where(p => p.MaisVendido)
                .ToListAsync();
        }

        public async Task<Produto> ObterDetalheProdutoAsync(int id)
        {
            var detalheProduto = await _dbContext.Produtos.AsNoTracking()
                                                  .FirstOrDefaultAsync(p => p.Id == id);

            if (detalheProduto is null)
                throw new InvalidOperationException();

            return detalheProduto;
        }
    }
}
