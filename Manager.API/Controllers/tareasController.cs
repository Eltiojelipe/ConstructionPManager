using Manager.API.Data;
using Manager.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manager.API.Controllers
{


    [ApiController]
    [Route("/api/tareas")]
    public class tareasController : ControllerBase
    {

        private readonly DataContext _context;

        public tareasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Tareas.ToListAsync());

        }


        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {

            var tarea = await _context.Tareas.FirstOrDefaultAsync(x => x.Id == id);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Tarea tarea)
        {
            _context.Add(tarea);
            await _context.SaveChangesAsync();
            return Ok(tarea);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Tarea tarea)
        {

            _context.Update(tarea);
            await _context.SaveChangesAsync();
            return Ok(tarea);

        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.Tareas

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