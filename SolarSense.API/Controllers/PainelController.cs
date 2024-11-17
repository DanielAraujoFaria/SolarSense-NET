using Microsoft.AspNetCore.Mvc;
using SolarSense.Database.Models;
using SolarSense.Repository.Interface;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace SolarSense.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PainelController : ControllerBase
    {
        private readonly IRepository<Painel> _painelRepository;

        public PainelController(IRepository<Painel> painelRepository)
        {
            _painelRepository = painelRepository;
        }

        /// <summary>
        /// Cadastra um novo painel.
        /// </summary>
        /// <param name="painel">Objeto painel a ser criado.</param>
        /// <returns>O painel recém-criado.</returns>
        /// <remarks>
        /// Exemplo de requisição (Lembre-se que é necessário cadastrar um Usuário antes de fazer este POST!):
        /// 
        ///     POST /Painel
        ///     {
        ///         "id": 1,
        ///         "idCliente": 1,
        ///         "nome": "Painel Solar Modelo X",
        ///         "potencia": 350,
        ///         "localizacao": "Rooftop - Setor Norte",
        ///         "tipoPainel": "Monocristalino",
        ///         "dataInstalacao": "2024-01-15"
        ///     }
        /// </remarks>
        /// <response code="201">Painel criado com sucesso.</response>
        /// <response code="400">O painel fornecido é inválido.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Painel painel)
        {
            _painelRepository.Add(painel);
            return Created();
        }

        /// <summary>
        /// Retorna todos os paineis cadastrados.
        /// </summary>
        /// <returns>Lista de paineis.</returns>
        /// <response code="200">Lista de paineis retornada com sucesso.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Painel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)] 
        public IActionResult GetAll()
        {
            var painel = _painelRepository.GetAll();
            return Ok(painel);
        }

        /// <summary>
        /// Retorna um Painel específico pelo ID.
        /// </summary>
        /// <param name="id">ID do painel.</param>
        /// <returns>Objeto painel.</returns>
        /// <response code="200">painel encontrado.</response>
        /// <response code="404">painel não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Painel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetById(int id)
        {
            var painel = _painelRepository.GetById(id);
            if (painel == null)
            {
                return NotFound();
            }
            return Ok(painel);
        }

        /// <summary>
        /// Atualiza um painel existente.
        /// </summary>
        /// <param name="id">ID do painel a ser atualizado.</param>
        /// <param name="painel">Dados atualizados do painel.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="200">Painel atualizado com sucesso.</response>
        /// <response code="404">Painel não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Put(int id, [FromBody] Painel painel)
        {
            var existingPainel = _painelRepository.GetById(id);
            if (existingPainel == null)
            {
                return NotFound();
            }

            painel.Id = id;
            _painelRepository.Update(painel);
            return Ok();
        }

        /// <summary>
        /// Exclui um painel pelo ID.
        /// </summary>
        /// <param name="id">ID do painel a ser excluído.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="204">Painel excluído com sucesso.</response>
        /// <response code="404">Painel não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete(int id)
        {
            var painel = _painelRepository.GetById(id);
            if (painel == null)
            {
                return NotFound();
            }

            _painelRepository.Delete(painel);
            return NoContent();
        }
    }
}
