using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenacStore.API.DTOs;
using SenacStore.API.Interfaces;
using SenacStore.API.Models;

namespace SenacStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _produtoRepository.GetAllAsync();

            if (produtos.Count == 0)
                return NotFound("");

            var produtosDTO = produtos.Select(produto => new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Imagem = produto.Imagem,
                Preco = produto.Preco,
                EhLancamento = produto.EhLancamento,
                Nota = produto.Nota,
                Categoria = produto.Categoria.Nome
            }).ToList();

            return Ok(produtosDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);

            if (produto == null)
                return NotFound();

            var produtoDTO = new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Imagem = produto.Imagem,
                Preco = produto.Preco,
                EhLancamento = produto.EhLancamento,
                Nota = produto.Nota,
                Categoria = produto.Categoria.Nome
            };

            return Ok(produtoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoDTO produtoDTO)
        {
            var produto = new Produto
            {
                Id = produtoDTO.Id,
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao,
                Imagem = produtoDTO.Imagem,
                Preco = produtoDTO.Preco,
                EhLancamento = produtoDTO.EhLancamento,
                Nota = produtoDTO.Nota,
                CategoriaId = produtoDTO.CategoriaId
            };

            await _produtoRepository.AddAsync(produto);

           var teste =   CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
            return teste;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ProdutoDTO produtoDTO)
        {
            var produto = new Produto
            {
                Id = produtoDTO.Id,
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao,
                Imagem = produtoDTO.Imagem,
                Preco = produtoDTO.Preco,
                EhLancamento = produtoDTO.EhLancamento,
                Nota = produtoDTO.Nota,
                CategoriaId = produtoDTO.CategoriaId
            };

            await _produtoRepository.UpdateAsync(produto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
