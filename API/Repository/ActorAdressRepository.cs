using API.Context;
using API.IRepository;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ActorAdressRepository : Controller, IActorAdressRepository
    {
        private readonly ContextDB _dbContext;
        public ActorAdressRepository(ContextDB dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ActorAdress>> GetActorAdress()
        {
           var results = await _dbContext.ActorAdress.ToListAsync();
           return results;
        }

        public async Task<ActorAdress> GetActorAdressById(Guid id)
        {
            var result = await _dbContext.ActorAdress.FindAsync(id);
            
            return result;
        }

        public async Task<ActorAdress> GetActorAdressByZipCode(int zipcode)
        {

            List<ActorAdress> actorsAdr = new List<ActorAdress>();
            actorsAdr = await _dbContext.ActorAdress.ToListAsync();

            var result = actorsAdr.Where(a => a.ZipCode == zipcode).FirstOrDefault();

            return result;
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

        public async Task DeleteActorAdress(Guid id)
        {
            var actorAdr = await _dbContext.ActorAdress.FindAsync(id);
            if (actorAdr != null)
            {
                _dbContext.ActorAdress.Remove(actorAdr);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
