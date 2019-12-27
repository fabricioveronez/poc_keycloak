using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Api.Model
{
    public class Produto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
        public string Categoria { get; set; }
    }
}
