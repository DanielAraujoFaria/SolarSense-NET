using Microsoft.AspNetCore.Mvc;
using SolarSense.Database.Models;
using SolarSense.Repository.Interface;
using System.Net;

namespace SolarSense.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddUsuarioController : ControllerBase
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public AddUsuarioController(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="usuario">Objeto usuário a ser criado.</param>
        /// <returns>O usuário recém-criado.</returns>
        /// <remarks>
        /// Exemplo 1: Usuário Cliente
        /// 
        ///     POST /Usuario
        ///     {
        ///         "id": 1,
        ///         "nome": "Maria Oliveira",
        ///         "email": "maria.oliveira@exemplo.com",
        ///         "senha": "senhaSegura123",
        ///         "tipo": "CLIENTE",
        ///         "notificacoes": "SIM",
        ///         "dataCadastro": "2024-11-15"
        ///     }
        /// 
        /// Exemplo 2: Usuário Administrador
        /// 
        ///     POST /Usuario
        ///     {
        ///         "id": 2,
        ///         "nome": "Carlos Souza",
        ///         "email": "carlos.souza@exemplo.com",
        ///         "senha": "senha1234",
        ///         "tipo": "ADMIN",
        ///         "notificacoes": "SIM",
        ///         "dataCadastro": "2024-11-15"
        ///     }
        /// </remarks>
        /// <response code="201">Usuário criado com sucesso.</response>
        /// <response code="400">O usuário fornecido é inválido.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            _usuarioRepository.Add(usuario);

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        /// <summary>
        /// Retorna todos os usuários cadastrados.
        /// </summary>
        /// <returns>Lista de usuários.</returns>
        /// <response code="200">Lista de usuários retornada com sucesso.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Usuario>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var usuarios = _usuarioRepository.GetAll();
            return Ok(usuarios);
        }

        /// <summary>
        /// Retorna um Usuário específico pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <returns>Objeto usuário.</returns>
        /// <response code="200">Usuário encontrado.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetById(int id)
        {
            var usuario = _usuarioRepository.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="id">ID do usuário a ser atualizado.</param>
        /// <param name="usuario">Dados atualizados do usuário.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="200">Usuário atualizado com sucesso.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            var existingUsuario = _usuarioRepository.GetById(id);
            if (existingUsuario == null)
            {
                return NotFound();
            }

            usuario.Id = id;
            _usuarioRepository.Update(usuario);
            return Ok();
        }

        /// <summary>
        /// Exclui um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser excluído.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="204">Usuário excluído com sucesso.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete(int id)
        {
            var usuario = _usuarioRepository.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioRepository.Delete(usuario);
            return NoContent();
        }
    }
}
