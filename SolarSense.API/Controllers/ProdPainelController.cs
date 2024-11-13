using Microsoft.AspNetCore.Mvc;
using SolarSense.Database.Models;
using SolarSense.Repository.Interface;
using System.Net;

namespace SolarSense.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdPainelController : ControllerBase
    {
        private readonly IRepository<ProducaoPainel> _producaoRepository;

        public ProdPainelController(IRepository<ProducaoPainel> producaoRepository)
        {
            _producaoRepository = producaoRepository;
        }

        /// <summary>
        /// Cadastra uma nova produção de painel.
        /// </summary>
        /// <param name="producao">Objeto de produção de painel a ser criado.</param>
        /// <returns>O painel de produção recém-criado.</returns>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /ProdPainel
        ///     {
        ///         "id": 1,
        ///         "idPainel": 2,
        ///         "dataMedicao": "2024-10-20T14:30:00Z",
        ///         "energia": 500.5,
        ///         "eficiencia": 85.7,
        ///         "alerta": false
        ///     }
        /// </remarks>
        /// <response code="201">Produção de painel criada com sucesso.</response>
        /// <response code="400">A produção de painel fornecida é inválida.</response>
        /// <response code="500">Erro interno do servidor.</response>   
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] ProducaoPainel producao)
        {
            _producaoRepository.Add(producao);
            return Created();
        }

        /// <summary>
        /// Retorna todos as produções dos paineis cadastradas.
        /// </summary>
        /// <returns>Lista de produções dos paineis.</returns>
        /// <response code="200">Lista de produções dos paineis retornada com sucesso.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<ProducaoPainel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var producao = _producaoRepository.GetAll();
            return Ok(producao);
        }

        /// <summary>
        /// Retorna uma produção de um painel específico pelo ID.
        /// </summary>
        /// <param name="id">ID da produção.</param>
        /// <returns>Objeto produção.</returns>
        /// <response code="200">produção do painel encontrada.</response>
        /// <response code="404">produção do painel não encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProducaoPainel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetById(int id)
        {
            var producao = _producaoRepository.GetById(id);
            if (producao == null)
            {
                return NotFound();
            }
            return Ok(producao);
        }

        /// <summary>
        /// Atualiza uma produção de um painel existente.
        /// </summary>
        /// <param name="id">ID de produção do painel a ser atualizado.</param>
        /// <param name="painel">Dados atualizados da produção do painel.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="200">Produção do painel atualizada com sucesso.</response>
        /// <response code="404">Produção do painel não encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Put(int id, [FromBody] ProducaoPainel producao)
        {
            var existingProducao = _producaoRepository.GetById(id);
            if (existingProducao == null)
            {
                return NotFound();
            }

            producao.Id = id;
            _producaoRepository.Update(producao);
            return Ok();
        }

        /// <summary>
        /// Exclui uma produção de um painel pelo ID.
        /// </summary>
        /// <param name="id">ID da produção de painel a ser excluída.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="204">Produção de painel excluída com sucesso.</response>
        /// <response code="404">Produção de painel não encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete(int id)
        {
            var producao = _producaoRepository.GetById(id);
            if (producao == null)
            {
                return NotFound();
            }

            _producaoRepository.Delete(producao);
            return NoContent();
        }
    }
}
