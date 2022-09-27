using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]

    //Acest atribut indica faptul ca controlul raspunde la solicitarile API-ului web
    [ApiController]
    public class ActorsController : Controller
    {
        //inject the database context 
        private readonly ContextDB _dbContext;

        public ActorsController(ContextDB dbContext)
        {
            _dbContext = dbContext;
        }

        //We will add CRUD action

        //1. GET Method:   api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            if (_dbContext.Actors == null)
            {
                return NotFound();
            }

            return await _dbContext.Actors.ToListAsync();
        }

        //1. GET Method:   api/Actors/5

        [HttpGet("id")]
        public async Task<ActionResult<Actor>> GetActor(Guid id)
        {
            if (_dbContext.Actors == null)
            {
                return NotFound();
            }

            var Actor = await _dbContext.Actors.FindAsync(id);

            if (Actor == null)
            {
                return NotFound();
            }
            return Actor;
        }

        //post
        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(Actor Actor)
        {
            _dbContext.Actors.Add(Actor);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActor), new { id = Actor.Id }, Actor);
        }


        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActor(Guid id, Actor Actor)
        {
            if (id != Actor.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(Actor).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool ActorExists(Guid id)
        {
            return (_dbContext.Actors?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        #region "Delete"
        //DELETE
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            if (_dbContext.Actors == null)
            {
                return NotFound();
            }

            var Actor = await _dbContext.Actors.FindAsync(id);
            if (Actor == null)
            {
                return NotFound();
            }

            _dbContext.Actors.Remove(Actor);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}
