using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_API.Domain.Entities;
using Projeto_API.Domain.Interfaces;
using Projeto_API.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public ProdutoController()
        {
            _repository = new ProdutoRepository();
        }
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
                return Ok(new { statusCode = 400, message = "Nada foi encontrado com o id " + id, item });
            else
                return Ok(new { statusCode = 200, message = "OK", item });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto item)
        {
            _repository.Save(item);
            return Ok(new
            {
                statusCode = 200,
                message = "Cadastrado com sucesso.",
                item
            });
        }

        [HttpPut]
        public IActionResult Put([FromBody] Produto item)
        {
            _repository.Update(item);
            return Ok(new
            {
                statusCode = 200,
                message = "Person autalizado com sucesso.",
                item
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.Delete(id))
                return Ok(new { statusCode = 200, message = "Deletado com sucesso" });
            else
                return Ok(new { statusCode = 500, message = "Ops!! Algo deu errado... tente novamente." });
        }


    }
}