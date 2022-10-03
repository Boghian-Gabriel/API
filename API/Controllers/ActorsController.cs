using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private  IActorRepository _actorRepository;

        //Dependency Injection => atunci cand  este nevoie se instantiaza clasa 
        public ActorsController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        //We will add CRUD action

        //1. GET Method:   api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            var rezult = await _actorRepository.GetActors();

            return rezult;
        }

        //1. GET Method:   api/Movies/5

        [HttpGet("id")]
        public async Task<ActionResult<Actor>> GetActorById(Guid id)
        {
            var rezult = await _actorRepository.GetActorById(id);
            return rezult;
        }

        [HttpGet("name")]
        public async Task<ActionResult<Actor>> GetActorByName(string fname,  string lname)
        {
            var rezult = await _actorRepository.GetActorByName(fname, lname);
            return rezult;
        }

        //post
        [HttpPost]
        [Authorize]
        /*
         example ad actor from swagger
        {
          "FirstName": "string",
          "LastName": "string",
          "Adress": {},
          "Movies": []
        }
         */
        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
           var rezult = await _actorRepository.PostActor(actor);

            return rezult;
        }

        //PUT
        [HttpPut("{id}")]
        [Authorize]
        /*
         example update API UpdateActor
        uid-ul pus in swagger trebuie sa fie la fel ca acesta pus de aici si apoi introduci
        ps: momentan am adaugat sa fie null la adress si movies
        {
          "ActorId": "3FA85F64-5717-4562-B3FC-2C963F66AFA6",
          "FirstName": "Boghian",
          "LastName": "Gabriel",
          "Adress": {},
          "Movies": []
        }
         */
        public async Task<IActionResult> UpdateActor(Guid id, Actor actor)
        {
            var rezult = await _actorRepository.UpdateActor(id, actor);
            return rezult;
        }


        #region "Delete"
        //DELETE
        [HttpDelete("id")]
        //auth
        [Authorize]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            var rezult = await _actorRepository.DeleteActor(id);

            return rezult;
        }
        #endregion
    }
}
