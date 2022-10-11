using API.IRepository;
using API.Model;
using API.ViewModel_BindModel_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private  IActorRepository _actorRepository;

        public ActorsController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            var result = await _actorRepository.GetActors();

            return result;
        }

        [HttpGet("id")]
        public async Task<ActionResult<Actor>> GetActorById(Guid id)
        {
            var result = await _actorRepository.GetActorById(id);
            return result;
        }

        [HttpGet("name")]
        public async Task<ActionResult<Actor>> GetActorByName(string fname,  string lname)
        {
            var result = await _actorRepository.GetActorByName(fname, lname);
            return result;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
           var result = await _actorRepository.PostActor(actor);

            return result;
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateActor(Guid id, Actor actor)
        {
            var result = await _actorRepository.UpdateActor(id, actor);
            return result;
        }


        #region "Delete"
        //DELETE
        [HttpDelete("id")]
        //auth
        [Authorize]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            var result = await _actorRepository.DeleteActor(id);

            return result;
        }
        #endregion

        [HttpGet]
        public async Task<IEnumerable<ActorAdressVM>> GetActorsWithAdress()
        {
            var result = await _actorRepository.GetActorsWithAdress();

            return result;
        }
    }
}
