using MongoDB.Driver;
using POC.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Api.Service
{
    public class ProdutoService
    {

        private IMongoCollection<Produto> _collection;

        public ProdutoService(IMongoDatabase database)
        {
            this._collection = database.GetCollection<Produto>("Produto");
        }

        public void Inserir(Produto produto)
        {
            this._collection.InsertOne(produto);
        }

        public void Salvar(Produto produto)
        {
            this._collection.ReplaceOne(obj => obj.Id.Equals(produto.Id), produto);
        }

        public ICollection<Produto> Listar()
        {
            return this._collection.Find(FilterDefinition<Produto>.Empty).ToList();
        }

        public Produto ListarPorId(string id)
        {
            return this._collection.Find(obj=> obj.Id.Equals(id)).First();
        }

        public void Excluir(int id)
        {
            this._collection.FindOneAndDelete(obj => obj.Id.Equals(id));
        }
    }
}
