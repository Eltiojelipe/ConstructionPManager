using Manager.API.Data;
using Manager.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manager.API.Controllers
{

    [ApiController]
    [Route("/api/materiales")]
    public class materialesController : ControllerBase
    {

        private readonly DataContext _context;

        public materialesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Materiales.ToListAsync());

        }


        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {

            var material = await _context.Materiales.FirstOrDefaultAsync(x => x.Id == id);

            if (material == null)
            {
                return NotFound();
            }

            return Ok(material);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Material material)
        {
            _context.Add(material);
            await _context.SaveChangesAsync();
            return Ok(material);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Material material)
        {

            _context.Update(material);
            await _context.SaveChangesAsync();
            return Ok(material);

        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.Materiales

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