using API.IRepository;
using API.Model;
using API.ModelsDTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    #region "ActorAdressController class"
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActorAdressController : ControllerBase
    {
        #region "Properties"
        private readonly IActorAdressRepository _actorAdressRepository;
        private readonly IMapper _mapper;
        #endregion

        #region "Constructor"
        public ActorAdressController(IActorAdressRepository actorAdressRepository, IMapper mapper)
        {
            _actorAdressRepository = actorAdressRepository;
            _mapper = mapper;
        }
        #endregion

        #region "Gel All ActorAdress"
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorAdressDTO>>> GetActorAdress()
        {
            try
            {
                var results = await _actorAdressRepository.GetActorAdress();
                if (results != null)
                {
                    var resMapper = _mapper.Map<IEnumerable<ActorAdressDTO>>(results);
                    return Ok(resMapper);
                }
                else
                {
                    return NotFound("There is no information");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }
        #endregion

        #region "GetActorAdressById"
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorAdressDTO>> GetActorAdressById(Guid id)
        {
            try
            {
                var result = await _actorAdressRepository.GetActorAdressById(id);
                if (result != null)
                {
                    var resActAdrMapper = _mapper.Map<ActorAdressDTO>(result);
                    return Ok(resActAdrMapper);
                }
                else
                {
                    return NotFound($"The ActorAdress with id: ' {id} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }
        #endregion

        #region "GetActorAdressByZipCode"
        [HttpGet("zip")]
        public async Task<ActionResult<ActorAdressDTO>> GetActorAdressByZipCode(int zip)
        {
            try
            {
                var result = await _actorAdressRepository.GetActorAdressByZipCode(zip);
                if (result != null)
                {
                    var resMapper = _mapper.Map<ActorAdressDTO>(result);
                    return Ok(resMapper);
                }
                else
                {
                    return NotFound($"The ActorAdress with zipCode: ' {zip} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }

        }
        #endregion

        #region "PostActorAdress"
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<ActorAdress>> PostActorAdress(InsertActorAdressWithActorID actorAdrDto)
        {
            var actorAdress= _mapper.Map<ActorAdress>(actorAdrDto);

            var result = await _actorAdressRepository.PostActorAdress(actorAdress);

            return result;
        }
        #endregion

        #region "UpdateActorAdress"
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateActorAdress(Guid id, UpdateActorAdressDTO actorAdrDTO)
        {
            try
            {
                var actorAdr = _mapper.Map<ActorAdress>(actorAdrDTO);
                if (actorAdr != null)
                {
                    var result = await _actorAdressRepository.UpdateActorAdress(id, actorAdr);
                    return result;
                }
                else
                {
                    return NotFound($"The ActorAdress with id: ' {id} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Error retrieving data from the database" + ex);
            }
        }
        #endregion

        #region "Delete"
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            var result = await _actorAdressRepository.DeleteActorAdress(id);

            return result;
        }
        #endregion
    }
    #endregion
}
