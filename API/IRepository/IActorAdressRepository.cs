using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.IRepository
{
    public interface IActorAdressRepository
    {
        Task<ActionResult<IEnumerable<ActorAdress>>> GetActorAdress();
        Task<ActionResult<ActorAdress>> GetActorAdressById(Guid id);
        Task<ActionResult<ActorAdress>> GetActorAdressByZipCode(int zipcode);
        Task<ActionResult<ActorAdress>> PostActorAdress(ActorAdress actorAdress);
        Task<IActionResult> UpdateActorAdress(Guid id, ActorAdress actorAdress);
        Task<IActionResult> DeleteActorAdress(Guid id);
    }
}
