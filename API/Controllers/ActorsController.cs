using API.IRepository;
using API.Model;
using API.ModelsDTO.ActorDto;
using API.ModelsDTO.MovieDto;
using API.Repository;
using API.ViewModel_BindModel_;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    #region "ActorsController class"
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        #region "Properties"
        private IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        #endregion

        #region "Constructor"
        public ActorsController(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }
        #endregion

        #region "GetActors"
        [HttpGet]
        public async Task<ActionResult<ActorDTO>> GetActors()
        {       
            try
            {
                var results = await _actorRepository.GetActors();
                if (results != null)
                {
                    var resActorMapper = _mapper.Map<IEnumerable<ActorDTO>>(results);
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
        #endregion

        #region "GetActorById"
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDTO>> GetActorById(Guid id)
        {
            try
            {
                var result = await _actorRepository.GetActorById(id);
                if (result != null)
                {
                    var resActorMapper = _mapper.Map<ActorDTO>(result);
                    return Ok(resActorMapper);
                }
                else
                {
                    return NotFound($"The actor with id: ' {id} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }
        #endregion

        #region "GetActorByName"
        [HttpGet("name")]
        public async Task<ActionResult<ActorDTO>> GetActorByName(string fname,  string lname)
        {          
            try
            {
                var result = await _actorRepository.GetActorByName(fname, lname);
                if (result != null)
                {
                    var resActorMapper = _mapper.Map<ActorDTO>(result);
                    return Ok(resActorMapper);
                }
                else
                {
                    return NotFound($"The actor with first name: ' {fname} ' and last name: '{lname}' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }
        #endregion

        #region "GetActorsWithAdress"
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorAdressVM>>> GetActorsWithAdress()
        {
            try
            {
                var results = await _actorRepository.GetActorsWithAdress();
                if (results != null)
                {
                    return Ok(results);
                }
                else
                {
                    return NotFound("There is no information!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error " + ex.Message);
            }
        }
        #endregion

        #region "PostActor"
        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(ActorDTO actorDTO)
        {  
            try
            {
                var existActor = await _actorRepository.GetActorByName(actorDTO.FirstName, actorDTO.LastName);
                if (existActor != null)
                {
                    ModelState.AddModelError("Actor", $"The actor with first name = {actorDTO.FirstName} and last name {actorDTO.LastName} already exists");
                    return BadRequest(ModelState);
                }

                var actor = _mapper.Map<Actor>(actorDTO);
                var result = await _actorRepository.PostActor(actor);

                //return result;
                return StatusCode(StatusCodes.Status201Created, "Added successfully");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error" + ex.Message);
            }
        }
        #endregion

        #region "UpdateActor"
        [HttpPut]
        public async Task<IActionResult> UpdateActor(Guid id, ActorDTO actorDTO)
        {
            try
            {
                var actor = _mapper.Map<Actor>(actorDTO);

                if (actor != null)
                {
                    var result = await _actorRepository.UpdateActor(id, actor);
                    return Ok(result);
                }
                else
                {
                    return BadRequest($"The actor was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error" + ex);
            }
        }
        #endregion

        #region "Delete"
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            try
            {
                var result = await _actorRepository.GetActorById(id);

                if (result == null)
                {
                    return NotFound($"Actor with Id: ' {id} ' not found!");
                }

                await _actorRepository.DeleteActor(id);

                return Ok($"Actor with Id: ' {id} ' is deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error" + ex.Message);
            }
        }
        #endregion

        
    }
    #endregion
}
