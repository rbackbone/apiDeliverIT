using deliverAPI.Data;
using deliverAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverAPI.Controllers
{
    [ApiController]
    [Route("api/v1/contas")]
    public class contasController : ControllerBase
    {
        // GET:
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<clContas>>> Get([FromServices] contasDbContext context)
        {
            var ret = await context.clContas.ToListAsync();

            return ret;
        }

        // POST:
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<clContas>> Post(
            [FromServices] contasDbContext context,
            [FromBody] clContas contaItem)
        {
            if (ModelState.IsValid)
            {                
                context.clContas.Add(contaItem);

               // System.Console.WriteLine(contaItem.DiasAtraso);
 
                await context.SaveChangesAsync();
                return contaItem;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}