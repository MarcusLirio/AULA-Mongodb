using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;
using DatabaseSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProdutoService
    {
        private readonly IMongoCollection<Produtos> _produtosColleciton;

        public ProdutoService(IOptions<ProdutoDatabaseSettings> produtoServices)
        {
            var mongoClient = new MongoClient(produtoServices.Value.ConnecttionString);

            var mongoDatabase = mongoClient.GetDatabase(produtoServices.Value.DatabaseName);

            _produtosColleciton = mongoDatabase.GetCollection<Produtos>
                (produtoServices.Value.ProdutoColletionName);
        }

        public async Task<List<Produtos>> GetAsync() =>
            await _produtosColleciton.Find(x => true).ToListAsync();

        public async Task<Produtos> GetAsync(string id) =>
            await _produtosColleciton.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Produtos produtos) =>
            await _produtosColleciton.InsertOneAsync(produtos);

        public async Task UpdateAsync(string id, Produtos produtos) =>
            await _produtosColleciton.ReplaceOneAsync(x => x.Id == id, produtos);

        public async Task DeleteAsync(string id) =>
            await _produtosColleciton.DeleteOneAsync(id);
    }
}
