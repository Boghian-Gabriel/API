using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ActorAdressRepository : Controller, IActorAdressRepository
    {
        private readonly ContextDB _dbContext;
        //constructor
        public ActorAdressRepository(ContextDB dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<IEnumerable<ActorAdress>>> GetActorAdress()
        {
            if (_dbContext.ActorAdress == null)
            {
                return NotFound();
            }

            //Include another table
            var rezult = await _dbContext.ActorAdress.ToListAsync();

            return rezult;
        }

        public async Task<ActionResult<ActorAdress>> GetActorAdressById(Guid id)
        {
            if (_dbContext.ActorAdress == null)
            {
                return NotFound();
            }

            var rezult = await _dbContext.ActorAdress.FindAsync(id);

            if (rezult == null)
            {
                return NotFound();
            }
            return rezult;
        }

        public async Task<ActionResult<ActorAdress>> GetActorAdressByZipCode(int zipcode)
        {
            if (_dbContext.ActorAdress == null)
            {
                return NotFound();
            }
            List<ActorAdress> actorsAdr = new List<ActorAdress>();
            actorsAdr = await _dbContext.ActorAdress.ToListAsync();
            var rezult = actorsAdr.Where(a => a.ZipCode == zipcode).FirstOrDefault();

            if (rezult == null)
            {
                return NotFound();
            }
            return rezult;
        }


        public async Task<ActionResult<ActorAdress>> PostActorAdress(ActorAdress actorAdr)
        {
            _dbContext.ActorAdress.Add(actorAdr);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActorAdressById), new { id = actorAdr.ActorAdressId }, actorAdr);
        }

        public async Task<IActionResult> UpdateActorAdress(Guid id, ActorAdress actorAdr)
        {
            if (id != actorAdr.ActorAdressId)
            {
                return BadRequest();
            }

            _dbContext.Entry(actorAdr).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorAdrExists(id))
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

        private bool ActorAdrExists(Guid id)
        {
            return (_dbContext.ActorAdress?.Any(a => a.ActorAdressId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> DeleteActorAdress(Guid id)
        {
            if (_dbContext.ActorAdress == null)
            {
                return NotFound();
            }

            var actorAdr = await _dbContext.ActorAdress.FindAsync(id);
            if (actorAdr == null)
            {
                return NotFound();
            }

            _dbContext.ActorAdress.Remove(actorAdr);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
