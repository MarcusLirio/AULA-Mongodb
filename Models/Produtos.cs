using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Produtos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Produto_Nome")]
        public string ProdutoNome { get; set; } = null!;

        [BsonElement("Produto_Categoria")]
        public string CategoriaProduto { get; set; } = null!;

        [BsonElement("Produto_Acessorio")]
        public string AcessorioProduto { get; set; } = null!;

        [BsonElement("Produto_Valor")]
        public Decimal Valor { get; set; }
    }
}
