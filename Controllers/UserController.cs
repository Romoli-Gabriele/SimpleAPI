using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;

namespace SimpleAPI.Controllers



{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllModels()
        {
            var models = _context.Users.ToList();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetModelById(int id)
        {
            var model = _context.Users.FirstOrDefault(m => m.Id == id);

            if (model == null)
            {
                return NotFound("Modello non trovato.");
            }

            model.Role = _context.Roles.FirstOrDefault(r => r.Id == model.RoleId);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Il corpo della richiesta non è valido.");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetModelById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest("Il corpo della richiesta non è valido.");
            }

            var modello = _context.Users.FirstOrDefault(m => m.Id == id);

            if (modello == null)
            {
                return NotFound("Modello non trovato.");
            }

            modello.Name = user.Name;
            modello.Username = user.Username;
            modello.Password = user.Password;
            modello.RoleId = user.RoleId;

            _context.Users.Update(modello);
            _context.SaveChanges();

            return Ok(modello);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var modello = _context.Users.FirstOrDefault(m => m.Id == id);

            if (modello == null)
            {
                return NotFound("Modello non trovato.");
            }

            _context.Users.Remove(modello);
            _context.SaveChanges();

            return Ok(modello);
        }
    }
}
