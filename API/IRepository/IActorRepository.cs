using API.Model;
using API.ViewModel_BindModel_;
using Microsoft.AspNetCore.Mvc;

namespace API.IRepository
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetActors();
        Task<IEnumerable<ActorAdressVM>> GetActorsWithAdress();
        Task<Actor> GetActorById(Guid id);
        Task<Actor> GetActorByName(string fname, string lastname);
        Task<ActionResult<Actor>> PostActor(Actor actor);
        Task<IActionResult> UpdateActor(Guid id, Actor actor);
        Task<IActionResult> DeleteActor(Guid id);
    }
}
