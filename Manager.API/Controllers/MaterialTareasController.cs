using Manager.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Manager.Share.Entities;

namespace Manager.API.Controllers
{
    [ApiController]
    [Route("/api/MaterialTareasController")]
    public class MaterialTareasController : ControllerBase
    {
        private readonly DataContext _context;

        public MaterialTareasController(DataContext context)
        {
            _context = context;
        }

        //Método GET --- Select * From Equipos_ContruccionControllers
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.MaterialTareas.ToListAsync());
        }

        //Método POST- insertar en base de datos
        [HttpPost]

        public async Task<ActionResult> Post(MaterialTarea materialTarea)
        {

            _context.Add(materialTarea);
            await _context.SaveChangesAsync();
            return Ok(materialTarea);
        }

        //Posible error acá
        //GEt por párametro- select * from Proyectos_Construccion where id=1
        //https://localhost:7000/api/Equipos_Construccion/id:int?id=1
        [HttpGet("id:int")]

        public async Task<ActionResult> Get(int id)
        {

            var materialTarea = await _context
                .MaterialTareas.FirstOrDefaultAsync(x => x.Id == id);
            if (materialTarea == null)
            {


                return NotFound();  //404
            }

            return Ok(materialTarea);//200
        }

        //Método PUT- actualizar datos 
        [HttpPut]

        public async Task<ActionResult> Put(MaterialTarea materialTarea)
        {

            _context.Update(materialTarea);
            await _context.SaveChangesAsync();
            return Ok(materialTarea);
        }

        //Delete - Eliminar registros

        [HttpDelete("id:int")]

        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.MaterialTareas
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (filasafectadas == 0)
            {


                return NotFound();  //404
            }

            return NoContent();//204


        }
    }
}
