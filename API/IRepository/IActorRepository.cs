using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.IRepository
{
    public interface IActorRepository
    {
        Task<ActionResult<IEnumerable<Actor>>> GetActors();
        Task<ActionResult<Actor>> GetActorById(Guid id);
        Task<ActionResult<Actor>> GetActorByName(string fname, string lastname);
        Task<ActionResult<Actor>> PostActor(Actor actor);
        Task<IActionResult> UpdateActor(Guid id, Actor actor);
        Task<IActionResult> DeleteActor(Guid id);
    }
}
