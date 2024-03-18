using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using System;

namespace SimpleAPI.Controllers



{
    [ApiController]
    [Route("[controller]")]
    public class SalutiController : ControllerBase
    {

        private readonly AppDbContext _context;

        public SalutiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllModels()
        {
            var models = _context.MyModels.ToList();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetModelById(int id)
        {
            var model = _context.MyModels.FirstOrDefault(m => m.Id == id);

            if (model == null)
            {
                return NotFound("Modello non trovato.");
            }

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MyModel model)
        {
            if (model == null)
            {
                return BadRequest("Il corpo della richiesta non è valido.");
            }

            _context.MyModels.Add(model);
            _context.SaveChanges();

            // Utilizza il modello per accedere alle proprietà del JSON
            return Ok($"Valore ricevuto: {model.Proprietà1}, {model.Proprietà2}");
        }
    }
}
