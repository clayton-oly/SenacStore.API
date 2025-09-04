using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenacStore.API.DTOs;
using SenacStore.API.Interfaces;
using SenacStore.API.Models;
using SenacStore.API.Repositories;


namespace SenacStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _categoriaRepository.GetAllAsync();

            if (categorias.Count == 0)
                return NotFound("");

            var categoriasDTO = categorias.Select(categoria => new CategoriaDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
            }).ToList();

            return Ok(categoriasDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            if (categoria == null)
                return NotFound();

            var categoriaDTO = new CategoriaDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
            };

            return Ok(categoriaDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            var categoria = new Categoria
            {
                Id = categoriaDTO.Id,
                Nome = categoriaDTO.Nome,
            };

            await _categoriaRepository.AddAsync(categoria);

            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] CategoriaDTO categoriaDTO)
        {
            var categoria = new Categoria
            {
                Id = categoriaDTO.Id,
                Nome = categoriaDTO.Nome,
            };

            await _categoriaRepository.UpdateAsync(categoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoriaRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
