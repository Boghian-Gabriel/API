using API.IRepository;
using API.Model;
using API.ModelDTO;
using API.ViewModel_BindModel_;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public ActorsController(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ActorDTO>> GetActors()
        {       
            try
            {
                var result = await _actorRepository.GetActors();
                var resActorMapper = _mapper.Map<IEnumerable<ActorDTO>>(result);
                if (resActorMapper != null)
                {
                    return Ok(resActorMapper);
                }
                else
                {
                    return NotFound($"The is no information");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<ActorDTO>> GetActorById(Guid id)
        {
            try
            {
                var result = await _actorRepository.GetActorById(id);
                var resActorMapper = _mapper.Map<ActorDTO>(result);
                if (resActorMapper != null)
                {
                    return Ok(resActorMapper);
                }
                else
                {
                    return NotFound($"The actor with id: ' {id} ' was not foud!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }

        [HttpGet("name")]
        public async Task<ActionResult<ActorDTO>> GetActorByName(string fname,  string lname)
        {          
            try
            {
                var result = await _actorRepository.GetActorByName(fname, lname);
                var resActorMapper = _mapper.Map<ActorDTO>(result);
                if (resActorMapper != null)
                {
                    return Ok(resActorMapper);
                }
                else
                {
                    return NotFound($"The actor with first name: ' {fname} ' and last name: '{lname}' was not foud!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
           var result = await _actorRepository.PostActor(actor);
            return result;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActor(Guid id, Actor actor)
        {
            var result = await _actorRepository.UpdateActor(id, actor);
            return result;
        }


        #region "Delete"
        [HttpDelete]
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
