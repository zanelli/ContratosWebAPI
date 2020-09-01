using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContratosWebAPI.Controllers
{
    [Route("api/v1/prestacao")]
    [ApiController]
    public class PrestacaoController : ControllerBase
    {
        //[HttpGet]
        //[Route("{id:int}")]
        //public async Task<ActionResult<Prestacao>> Get([FromServices] DataContext context, int id)
        //{
        //    return await context.Prestacoes.Where(x => x.Id == id).FirstOrDefaultAsync();
        //}

        //[HttpGet]
        //[Route("contrato/{id:int}")]
        //public async Task<ActionResult<List<Prestacao>>> GetPorContrato([FromServices] DataContext context, int id)
        //{
        //    return await context.Prestacoes.Include(x => x.Contrato)
        //        .AsNoTracking()
        //        .Where(x => x.Contrato.Id == id)
        //        .ToListAsync();
        //}
    }
}
