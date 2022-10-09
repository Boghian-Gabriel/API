using API.IRepository;
using API.Model;
using API.ViewModel_BindModel_;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ActorRepository : Controller, IActorRepository
    {

        private readonly ContextDB _dbContext;

        //constructor
        /*
         In the ActorRepository.cs , the constructor uses dependency injection to inject the database context (ContextDB) into the repository.
         
         ContextDB is used in each of the CRUD methods in the ActorRepository.
         */

        public ActorRepository(ContextDB dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<Actor>> GetActorById(Guid id)
        {
            if (_dbContext.Actors == null)
            {
                return NotFound();
            }

            var rezult = await _dbContext.Actors.FindAsync(id);

            if (rezult == null)
            {
                return NotFound();
            }
            return rezult;
        }

        public async Task<ActionResult<Actor>> GetActorByName(string fname, string lastname)
        {
            if (_dbContext.Actors == null)
            {
                return NotFound();
            }
            List<Actor> actors = new List<Actor>();
            actors = await _dbContext.Actors.ToListAsync();
            var rezult = actors.Where(a => a.FirstName == fname && a.LastName ==lastname).FirstOrDefault();

            if (rezult == null)
            {
                return NotFound();
            }
            return rezult;
        }
 

        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
            _dbContext.Actors.Add(actor);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActorById), new { id = actor.ActorId }, actor);
        }

        public async Task<IActionResult> UpdateActor(Guid id, Actor actor)
        {
            if (id != actor.ActorId)
            {
                return BadRequest();
            }

            _dbContext.Entry(actor).State = EntityState.Modified;

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
            return (_dbContext.Actors?.Any(a => a.ActorId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> DeleteActor(Guid id)
        {
            if (_dbContext.Actors == null)
            {
                return NotFound();
            }

            var actor = await _dbContext.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }

            _dbContext.Actors.Remove(actor);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            if (_dbContext.Actors == null)
            {
                return NotFound();
            }

            //Include another table
            var rezult = await _dbContext.Actors.ToListAsync();

            return rezult;
        }

        public async Task<IEnumerable<ActorAdressVM>> GetActorsWithAdress()
        {
            var rezActorAdress = (from a in _dbContext.Actors
                                  join aa in _dbContext.ActorAdress on a.ActorId equals aa.ActorAdressId
                                  select new ActorAdressVM
                                  {
                                       Id = a.ActorId,
                                       FName = a.FirstName,
                                       LName = a.LastName,
                                       Adress1 = aa.Adress1,
                                       City = aa.City,
                                       ZipCode = aa.ZipCode

                                  }).ToListAsync();

            //obs in Entity Framework, many-to-many relationship are automatically joined
            //tabela de jonctiune o vom vedea in baza de date, nu si in entity framework
            return await rezActorAdress;
        }
    }
}
