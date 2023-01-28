using System.ComponentModel.DataAnnotations;
using WebApiContabilidad.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApiContabilidad.Contexts;

namespace WebApiContabilidad.Controllers
{

    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly AppDbContext context;

        public EstadoController(AppDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IActionResult GetEstados()
        {
            List<Estado> lst_est = context.estado.ToList();
            return Ok(lst_est);
        }

        [HttpGet("{est_id}")]
        public IActionResult GetEstadoByID(int est_id)
        {
            //List<estado> lst_est = context.estado.Where(x => x.est_id == est_id).ToList();
            Estado est = context.estado.Find(est_id);
            if (est == null)
            {
                return BadRequest("El estado no existe");
            }

            return Ok(est);
        }

        [HttpGet("{est_nombre}")]
        public IActionResult GetEstadoByNombre(string est_nombre)
        {
            Estado est = context.estado.Where(x => x.est_nombre == est_nombre).FirstOrDefault();
            return Ok(est);
        }

        [HttpPost()]
        public IActionResult AddEstado([FromBody] Estado estado)
        {
            Estado new_estado = new Estado();
            new_estado.est_nombre = estado.est_nombre;
            try
            {
                context.estado.Add(new_estado);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            
            return Ok();
        }
        

        [HttpPut]
        public IActionResult UpdateEstado([FromBody] Estado est)
        {
            context.Update(est);
            context.SaveChanges();
            return Ok(est);
        }

        [HttpDelete("{est_id}")]
        public IActionResult DeleteEstado(int est_id)
        {
            Estado est = context.estado.Find(est_id);
            context.Remove(est);
            context.SaveChanges();
            return Ok(est);
        }
        
    }
}


