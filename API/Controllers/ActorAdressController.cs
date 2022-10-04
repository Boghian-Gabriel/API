using API.IRepository;
using API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorAdressController : ControllerBase
    {
        private IActorAdressRepository _actorAdressRepository;

        //Dependency Injection => atunci cand  este nevoie se instantiaza clasa 
        public ActorAdressController(IActorAdressRepository actorAdressRepository)
        {
            _actorAdressRepository = actorAdressRepository;
        }
        //We will add CRUD action

        //1. GET Method:   api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorAdress>>> GetActorAdress()
        {
            var rezult = await _actorAdressRepository.GetActorAdress();

            return rezult;
        }

        //1. GET Method:   api/Movies/5

        [HttpGet("id")]
        public async Task<ActionResult<ActorAdress>> GetActorAdressById(Guid id)
        {
            var rezult = await _actorAdressRepository.GetActorAdressById(id);
            return rezult;
        }

        [HttpGet("zip")]
        public async Task<ActionResult<ActorAdress>> GetActorAdressByZipCode(int zip)
        {
            var rezult = await _actorAdressRepository.GetActorAdressByZipCode(zip);
            return rezult;
        }

        //post
        [HttpPost]
        [Authorize]

        public async Task<ActionResult<ActorAdress>> PostActorAdress(ActorAdress actorAdr)
        {
            var rezult = await _actorAdressRepository.PostActorAdress(actorAdr);

            return rezult;
        }

        //PUT
        [HttpPut("{id}")]
        [Authorize]
        /*
         example update API

         */
        public async Task<IActionResult> UpdateActorAdress(Guid id, ActorAdress actorAdr)
        {
            var rezult = await _actorAdressRepository.UpdateActorAdress(id, actorAdr);
            return rezult;
        }


        #region "Delete"
        //DELETE
        [HttpDelete("id")]
        //auth
        [Authorize]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            var rezult = await _actorAdressRepository.DeleteActorAdress(id);

            return rezult;
        }
        #endregion
    }
}
