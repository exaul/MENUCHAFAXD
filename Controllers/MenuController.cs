using Microsoft.AspNetCore.Mvc;
using TODOLOQUEPUEDASCOMER.Data;
using TODOLOQUEPUEDASCOMER.DTO;
using TODOLOQUEPUEDASCOMER.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TODOLOQUEPUEDASCOMER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ApiDbContext dbContext;

        public MenuController (ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<MenuController>
        [HttpGet]
        public IEnumerable<Menu> Get()
        {
            return dbContext.Menus;
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El id no debe de ser 0");
            }
            Menu menu = dbContext.Menus.Find(id);
            if (menu == null)
            {
                return NotFound("La musica no existe");
            }
            return Ok(menu);
        }

        // POST api/<MenuController>
        [HttpPost]
        public IActionResult Post([FromBody] MenuDTO newMenu)
        {
            if (newMenu == null)
            {
                return BadRequest("No se admiten datos vacíos");
            }
            if ((string.IsNullOrEmpty(newMenu.Platillo)) || string.IsNullOrEmpty(newMenu.Bebidas))
            {
                return BadRequest("los campos son obligatorios");
            }
            var menu = new Menu
            {
                Platillo = newMenu.Platillo,
                Bebidas = newMenu.Bebidas
            };
            dbContext.Menus.Add(menu);
            dbContext.SaveChanges();
            return Ok();
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Menu updateMenu)
        {
            if (updateMenu == null)
            {
                return BadRequest("Ingresaste datos nulos");
            }

            var existingMenu = dbContext.Menus.Find(id);

            if (existingMenu == null)
            {
                return BadRequest("No existe su Menu ");
            }


            existingMenu.Platillo = updateMenu.Platillo;
            existingMenu.Bebidas = updateMenu.Bebidas;

            dbContext.SaveChanges();
            return Ok();
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var menuToDelete = dbContext.Menus.Find(id);
            if (menuToDelete != null)
            {
                dbContext.Menus.Remove(menuToDelete);
                dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
