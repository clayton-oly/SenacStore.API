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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/<TiposController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            var resultado = new List<UsuarioDTO>();

            foreach (var tipo in usuarios)
            {
                resultado.Add(new UsuarioDTO
                {
                    Id = tipo.Id,
                    Nome = tipo.Nome,
                    Email = tipo.Email,
                    Senha = tipo.Senha
                });
            }

            return Ok(resultado);
        }

        // GET api/<TiposController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            //convertendo minha model dto em classe dto
            var resultado = new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            };

            return Ok(resultado);
        }

        // POST api/<TiposController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO dto)
        {
            //convertendo minha classe dto em classe model
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha
            };

            await _usuarioRepository.AddAsync(usuario);
            return Ok();
        }

        // PUT api/<TipoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDTO dto)
        {
            //convertendo minha classe dto em classe model
            var usuario = new Usuario
            {
                Id = id,
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha
            };

            await _usuarioRepository.UpdateAsync(usuario);
            return Ok();
        }

        // DELETE api/<TiposController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
            return Ok();
        }
    }
}