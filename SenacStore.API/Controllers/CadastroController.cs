using Microsoft.AspNetCore.Mvc;
using SenacStore.API.DTOs;
using SenacStore.API.Interfaces;
using SenacStore.API.Models;


namespace SenacStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroRepository _cadastroRepository;

        public CadastroController(ICadastroRepository cadastroRepository)
        {
            _cadastroRepository = cadastroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cadastros = await _cadastroRepository.GetAllAsync();

            if (cadastros.Count == 0)
                return NotFound("");

            var cadastrosDTO = cadastros.Select(cadastro => new CadastroDTO
            {
                Id = cadastro.Id,
                Nome = cadastro.Nome,
                Cpf = cadastro.Cpf,
                Email = cadastro.Email,
                Telefone = cadastro.Telefone,
                Endereco = cadastro.Endereco,
                Nro = cadastro.Nro,
                Bairro = cadastro.Bairro,
                Cidade = cadastro.Cidade,
                Estado = cadastro.Estado,
                DataCadastro = cadastro.DataCadastro,
            }).ToList();

            return Ok(cadastrosDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cadastro = await _cadastroRepository.GetByIdAsync(id);

            if (cadastro == null)
                return NotFound();

            var cadastroDTO = new CadastroDTO
            {
                Id = cadastro.Id,
                Nome = cadastro.Nome,
                Cpf = cadastro.Cpf,
                Email = cadastro.Email,
                Telefone = cadastro.Telefone,
                Endereco = cadastro.Endereco,
                Nro = cadastro.Nro,
                Bairro = cadastro.Bairro,
                Cidade = cadastro.Cidade,
                Estado = cadastro.Estado,
                DataCadastro = cadastro.DataCadastro,
            };

            return Ok(cadastroDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastroDTO cadastroDTO)
        {
            var cadastro = new Cadastro
            {
                Id = cadastroDTO.Id,
                Nome = cadastroDTO.Nome,
                Cpf = cadastroDTO.Cpf,
                Email = cadastroDTO.Email,
                Telefone = cadastroDTO.Telefone,
                Endereco = cadastroDTO.Endereco,
                Nro = cadastroDTO.Nro,
                Bairro = cadastroDTO.Bairro,
                Cidade = cadastroDTO.Cidade,
                Estado = cadastroDTO.Estado,
                DataCadastro = DateTime.Now,
            };

            await _cadastroRepository.AddAsync(cadastro);

            var teste = CreatedAtAction(nameof(GetById), new { id = cadastro.Id }, cadastro);
            return teste;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] CadastroDTO cadastroDTO)
        {
            var cadastro = new Cadastro
            {
                Id = cadastroDTO.Id,
                Nome = cadastroDTO.Nome,
                Cpf = cadastroDTO.Cpf,
                Email = cadastroDTO.Email,
                Telefone = cadastroDTO.Telefone,
                Endereco = cadastroDTO.Endereco,
                Nro = cadastroDTO.Nro,
                Bairro = cadastroDTO.Bairro,
                Cidade = cadastroDTO.Cidade,
                Estado = cadastroDTO.Estado,
                DataCadastro = DateTime.Now,
            };

            await _cadastroRepository.UpdateAsync(cadastro);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cadastroRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
