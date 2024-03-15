using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using System;

namespace SimpleAPI.Controllers



{
    [ApiController]
    [Route("[controller]")]
    public class SalutiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ciao, mondo!");
        }

        [HttpGet("{nome}")]
        public IActionResult Get(string nome)
        {
            return Ok($"Ciao, {nome}!");
        }

        [HttpPost]
        public IActionResult Post([FromBody] MyModel model)
        {
            if (model == null)
            {
                return BadRequest("Il corpo della richiesta non è valido.");
            }

            // Utilizza il modello per accedere alle proprietà del JSON
            return Ok($"Valore ricevuto: {model.Proprietà1}, {model.Proprietà2}");
        }
    }
}
