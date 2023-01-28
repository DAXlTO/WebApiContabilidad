using System.ComponentModel.DataAnnotations;
using WebApiContabilidad.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApiContabilidad.Contexts;

namespace WebApiContabilidad.Controllers
{

    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly AppDbContext context;

        public MarcaController(AppDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IActionResult GetMarca()
        {
            List<Marca> lst_mar = context.marca.ToList();
            return Ok(lst_mar);
        }

        [HttpGet("{mar_id}")]
        public IActionResult GetMarcaByID(int mar_id)
        {
            Marca mar = context.marca.Find(mar_id);
            if (mar == null)
            {
                return BadRequest("La marca no existe");
            }

            return Ok(mar);
        }

        [HttpGet("{mar_nombre}")]
        public IActionResult GetMarcaByNombre(string mar_nombre)
        {
            Marca mar = context.marca.Where(x => x.mar_nombre == mar_nombre).FirstOrDefault();
            return Ok(mar);
        }

        [HttpPost()]
        public IActionResult AddMarca([FromBody] Marca mar)
        {
            Marca new_mar = new Marca();
            new_mar.mar_est_id = mar.mar_est_id;
            new_mar.mar_nombre = mar.mar_nombre;
            new_mar.mar_comentario = mar.mar_comentario;
            try
            {
                context.marca.Add(new_mar);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok();
        }
        

        [HttpPut]
        public IActionResult UpdateMarca([FromBody] Marca mar)
        {
            context.Update(mar);
            context.SaveChanges();
            return Ok(mar);
        }

        [HttpDelete("{mar_id}")]
        public IActionResult DeleteMarca(int mar_id)
        {
            Marca mar = context.marca.Find(mar_id);
            context.Remove(mar);
            context.SaveChanges();
            return Ok(mar);
        }
        
    }
}


