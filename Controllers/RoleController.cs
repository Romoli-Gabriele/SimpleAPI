using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class RoleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllModels()
        {
            var models = _context.Roles.ToList();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetModelById(int id)
        {
            var model = _context.Roles.FirstOrDefault(m => m.Id == id);

            if (model == null)
            {
                return NotFound("Modello non trovato.");
            }

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Role role)
        {
            if (role == null)
            {
                return BadRequest("Il corpo della richiesta non è valido.");
            }

            _context.Roles.Add(role);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetModelById), new { id = role.Id }, role);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Role role)
        {
            if (role == null || role.Id != id)
            {
                return BadRequest("Il corpo della richiesta non è valido.");
            }

            var existingRole = _context.Roles.FirstOrDefault(m => m.Id == id);

            if (existingRole == null)
            {
                return NotFound("Modello non trovato.");
            }

            existingRole.Name = role.Name;
            existingRole.Slug = role.Slug;

            _context.Roles.Update(existingRole);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = _context.Roles.FirstOrDefault(m => m.Id == id);

            if (model == null)
            {
                return NotFound("Modello non trovato.");
            }

            _context.Roles.Remove(model);
            _context.SaveChanges();

            return NoContent();
        }
    }
}