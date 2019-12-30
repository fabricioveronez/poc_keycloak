using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC.Api.Model;
using POC.Api.Service;

namespace POC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            this._service = service;
        }

        // GET: api/Produto
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return this._service.Listar();
        }

        // GET: api/Produto/5
        [HttpGet("{id}", Name = "Get")]
        public Produto Get(string id)
        {
            return this._service.ListarPorId(id);
        }

        // POST: api/Produto
        [Authorize(Roles = "editar_produto")]
        [HttpPost]
        public void Post([FromBody] Produto produto)
        {
            this._service.Inserir(produto);
        }

        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Produto produto)
        {
            this._service.Salvar(produto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._service.Excluir(id);
        }
    }
}
