using Manager.API.Data;
using Manager.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manager.API.Controllers
{

    [ApiController]
    [Route("/api/proy_Construccions")]
    public class proy_ConstruccionsController : ControllerBase
    {

        private readonly DataContext _context;

        public proy_ConstruccionsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.proy_Construccions.ToListAsync());

        }


        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {

            var proy_Construccion = await _context.proy_Construccions.FirstOrDefaultAsync(x => x.Id == id);

            if (proy_Construccion == null)
            {
                return NotFound();
            }

            return Ok(proy_Construccion);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Equipos_Proy_Construccion proy_Construccion)
        {
            _context.Add(proy_Construccion);
            await _context.SaveChangesAsync();
            return Ok(proy_Construccion);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Equipos_Proy_Construccion proy_Construccion)
        {

            _context.Update(proy_Construccion);
            await _context.SaveChangesAsync();
            return Ok(proy_Construccion);

        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.proy_Construccions

                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (Filasafectadas == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
