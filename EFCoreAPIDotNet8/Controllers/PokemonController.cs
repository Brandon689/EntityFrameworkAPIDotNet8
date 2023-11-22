using EntityFrameworkAPIDotNet8.Data;
using EntityFrameworkAPIDotNet8.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkAPIDotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        private readonly DataContext _context;

        public PokemonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> GetAllPokemon()
        {
            var pokemon = await _context.Pokemon.ToListAsync();
            return Ok(pokemon);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(int id)
        {
            var pokemon = await _context.Pokemon.FindAsync(id);
            if (pokemon is null)
                return NotFound("Pokemon not found.");
            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pokemon>>> AddPokemon(Pokemon pokemon)
        {
            _context.Pokemon.Add(pokemon);
            await _context.SaveChangesAsync();
            return Ok(await _context.Pokemon.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Pokemon>>> UpdatePokemon(Pokemon updatedPokemon)
        {
            var dbPokemon = await _context.Pokemon.FindAsync(updatedPokemon.Id);
            if (dbPokemon is null)
                return NotFound("Pokemon not found.");
            dbPokemon.Name = updatedPokemon.Name;
            dbPokemon.Hp = updatedPokemon.Hp;
            dbPokemon.Description = updatedPokemon.Description;
            dbPokemon.Type = updatedPokemon.Type;

            await _context.SaveChangesAsync();
            return Ok(await _context.Pokemon.ToListAsync());
        }
    }
}
