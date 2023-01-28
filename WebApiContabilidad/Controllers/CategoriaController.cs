using System.ComponentModel.DataAnnotations;
using WebApiContabilidad.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApiContabilidad.Contexts;

namespace WebApiContabilidad.Controllers
{

    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext context;

        public CategoriaController(AppDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IActionResult GetCategoria()
        {
            List<Categoria> lst_cat = context.categoria.Where(x=>x.cat_est_id==1).ToList();
            return Ok(lst_cat);
        }

        [HttpGet("{cat_id}")]
        public IActionResult GetCategoriaByID(int cat_id)
        {
            //List<estado> lst_est = context.estado.Where(x => x.est_id == est_id).ToList();
            Categoria cat = context.categoria.Find(cat_id);
            if (cat == null)
            {
                return BadRequest("El tipo de movimiento no existe");
            }

            return Ok(cat);
        }

        [HttpGet("{cat_nombre}")]
        public IActionResult GetCategoriaByNombre(string cat_nombre)
        {
            Categoria cat = context.categoria.Where(x => x.cat_nombre == cat_nombre).FirstOrDefault();
            return Ok(cat);
        }

        [HttpPost()]
        public IActionResult AddCategoria([FromBody] Categoria cat)
        {
            Categoria new_cat = new Categoria();
            new_cat.cat_est_id = cat.cat_est_id;
            new_cat.cat_nombre = cat.cat_nombre;
            new_cat.cat_comentario = cat.cat_comentario;
            try
            {
                context.categoria.Add(new_cat);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok();
        }
        

        [HttpPut]
        public IActionResult UpdateCategoria([FromBody] Categoria cat)
        {
            context.Update(cat);
            context.SaveChanges();
            return Ok(cat);
        }
        
        [HttpPut]
        public IActionResult UpdateCategoriaEstado([FromBody] CategoriaEstado cat)
        {
            context.categoria.Find(cat.cat_id).cat_est_id = cat.cat_est_id;
            context.SaveChanges();
            return Ok(cat);
        }
        
        [HttpDelete("{cat_id}")]
        public IActionResult DeleteCategoria(int cat_id)
        {
            Categoria cat = context.categoria.Find(cat_id);
            context.Remove(cat);
            context.SaveChanges();
            return Ok(cat);
        }
        
    }
}


