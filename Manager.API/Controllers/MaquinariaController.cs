using Manager.API.Data;
using Manager.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manager.API.Controllers
{


    [ApiController]
    [Route("/api/maquinaria")]
    public class maquinariaController : ControllerBase
    {

        private readonly DataContext _context;

        public maquinariaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.maquinaria.ToListAsync());

        }


        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {

            var tarea = await _context.maquinaria.FirstOrDefaultAsync(x => x.Id == id);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Maquinaria maquinaria)
        {
            _context.Add(maquinaria);
            await _context.SaveChangesAsync();
            return Ok(maquinaria);
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
            var Filasafectadas = await _context.maquinaria

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