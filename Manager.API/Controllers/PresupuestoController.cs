using Manager.API.Data;
using Manager.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manager.API.Controllers
{


    [ApiController]
    [Route("/api/presupuesto")]
    public class presupuestoController : ControllerBase
    {

        private readonly DataContext _context;

        public presupuestoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.presupuesto.ToListAsync());

        }


        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {

            var tarea = await _context.presupuesto.FirstOrDefaultAsync(x => x.idPresupuesto == id);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Presupuesto presupuesto)
        {
            _context.Add(presupuesto);
            await _context.SaveChangesAsync();
            return Ok(presupuesto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Presupuesto presupuesto)
        {

            _context.Update(presupuesto);
            await _context.SaveChangesAsync();
            return Ok(presupuesto);

        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.presupuesto

                .Where(x => x.idPresupuesto == id)
                .ExecuteDeleteAsync();

            if (Filasafectadas == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}