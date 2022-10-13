using API.IRepository;
using API.Model;
using API.ModelDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActorAdressController : ControllerBase
    {
        private IActorAdressRepository _actorAdressRepository;

        public ActorAdressController(IActorAdressRepository actorAdressRepository)
        {
            _actorAdressRepository = actorAdressRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorAdressDTO>>> GetActorAdress()
        {
            var result = await _actorAdressRepository.GetActorAdress();

            return result;
        }

        [HttpGet("id")]
        public async Task<ActionResult<ActorAdress>> GetActorAdressById(Guid id)
        {
            var result = await _actorAdressRepository.GetActorAdressById(id);
            return result;
        }

        [HttpGet("zip")]
        public async Task<ActionResult<ActorAdress>> GetActorAdressByZipCode(int zip)
        {
            var result = await _actorAdressRepository.GetActorAdressByZipCode(zip);
            return result;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ActorAdress>> PostActorAdress(ActorAdress actorAdr)
        {
            var result = await _actorAdressRepository.PostActorAdress(actorAdr);

            return result;
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateActorAdress(Guid id, ActorAdress actorAdr)
        {
            var result = await _actorAdressRepository.UpdateActorAdress(id, actorAdr);
            return result;
        }

        #region "Delete"
        [HttpDelete("id")]
        [Authorize]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            var result = await _actorAdressRepository.DeleteActorAdress(id);

            return result;
        }
        #endregion
    }
}
