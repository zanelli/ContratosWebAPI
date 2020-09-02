using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContratosWebAPI.Aplicacao.Servico.Interfaces;
using ContratosWebAPI.Dominio.Entidades;
using ContratosWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.FeatureManagement;

namespace ContratosWebAPI.Controllers
{
    /// <summary>
    /// Endpoint para manipulação de contratos
    /// </summary>
    [Route("api/v1/contrato")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        readonly IServicoAplicacaoContrato ServicoAplicacaoContrato;

        public ContratoController(IServicoAplicacaoContrato servicoAplicacaoContrato)
        {
            ServicoAplicacaoContrato = servicoAplicacaoContrato;
        }

        /// <summary>
        /// Retorna todos os contratos e suas respectivas prestações
        /// </summary>
        /// <returns>Lista de contratos</returns>
        [HttpGet]
        public ActionResult<List<ContratoViewModelGet>> Get([FromServices] IMemoryCache cache)
        {
            ContratoViewModelGet contrato = new ContratoViewModelGet();
            return ServicoAplicacaoContrato.Listagem().ToList();

            //return await context.Contratos.AsNoTracking().Include(x => x.Prestacoes).ToListAsync();
        }

        /// <summary>
        /// Retorna um único contrato pelo seu Id, incluindo suas prestações
        /// </summary>
        /// <param name="id">Id do contrato</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ContratoViewModelGet>> GetAsync(
            [FromServices] IMemoryCache cache,
            [FromServices] IFeatureManager featureManager,
            int id)
        {
            if (await featureManager.IsEnabledAsync("InMemoryCache"))
            {
                var contrato = await cache.GetOrCreate<Task<ActionResult<ContratoViewModelGet>>>(id,
               async cacheEntry =>
               {
                   cacheEntry.AbsoluteExpiration = DateTime.Today.AddDays(1);
                   ContratoViewModelGet contrato = new ContratoViewModelGet();
                   return ServicoAplicacaoContrato.CarregarRegistro(id);
               });

                return contrato;
            }
            else
            {
                ContratoViewModelGet contrato = new ContratoViewModelGet();
                return ServicoAplicacaoContrato.CarregarRegistro(id);
            }
        }

        /// <summary>
        /// Grava um novo contrato, gerando suas parcelas automaticamente
        /// </summary>
        /// <param name="contrato">Dados do contrato a ser gerado</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ContratoViewModelGet> Post([FromBody] ContratoViewModelPost contrato)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoContrato.Cadastrar(contrato);

                ContratoViewModelGet contratoGet = new ContratoViewModelGet();

                return Ok(contrato);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        /// <summary>
        /// Exclui um contrato pelo seu Id
        /// </summary>
        /// <param name="id">Id do contrato a ser excluído</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            ServicoAplicacaoContrato.Excluir(id);
            return NoContent();
        }

        /// <summary>
        /// Atualiza um contrato pelo seu Id
        /// </summary>
        /// <param name="id">Id do contrato a ser editado</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, ContratoViewModelPut contrato)
        {
            if(id != contrato.Id)
            {
                return BadRequest();
            }
            ServicoAplicacaoContrato.Atualizar(contrato);
            return NoContent();
        }

    }
}
