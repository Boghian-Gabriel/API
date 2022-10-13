using API.Model;
using API.ModelDTO;
using API.ViewModel_BindModel_;
using Microsoft.AspNetCore.Mvc;

namespace API.IRepository
{
    public interface IActorRepository
    {
        Task<ActionResult<IEnumerable<ActorDTO>>> GetActors();
        Task<IEnumerable<ActorAdressVM>> GetActorsWithAdress();
        Task<ActionResult<Actor>> GetActorById(Guid id);
        Task<ActionResult<Actor>> GetActorByName(string fname, string lastname);
        Task<ActionResult<Actor>> PostActor(Actor actor);
        Task<IActionResult> UpdateActor(Guid id, Actor actor);
        Task<IActionResult> DeleteActor(Guid id);
    }
}
