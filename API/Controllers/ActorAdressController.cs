using API.IRepository;
using API.Model;
using API.ModelDTO;
using AutoMapper;
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
        private readonly IActorAdressRepository _actorAdressRepository;
        private readonly IMapper _mapper;

        public ActorAdressController(IActorAdressRepository actorAdressRepository, IMapper mapper)
        {
            _actorAdressRepository = actorAdressRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorAdressDTO>>> GetActorAdress()
        {
            try
            {
                var result = await _actorAdressRepository.GetActorAdress();
                var resMapper = _mapper.Map<IEnumerable<ActorAdressDTO>>(result);
                if (resMapper != null)
                {
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

        [HttpGet("id")]
        public async Task<ActionResult<ActorAdressDTO>> GetActorAdressById(Guid id)
        {
            try
            {
                var result = await _actorAdressRepository.GetActorAdressById(id);
                var resActAdrMapper = _mapper.Map<ActorAdressDTO>(result);
                if (resActAdrMapper != null)
                {
                    return Ok(resActAdrMapper);
                }
                else
                {
                    return NotFound($"The ActorAdress with id: ' {id} ' was not foud!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }

        [HttpGet("zip")]
        public async Task<ActionResult<ActorAdressDTO>> GetActorAdressByZipCode(int zip)
        {
            try
            {
                var result = await _actorAdressRepository.GetActorAdressByZipCode(zip);
                var resMapper = _mapper.Map<ActorAdressDTO>(result);
                if (resMapper != null)
                {
                    return Ok(resMapper);
                }
                else
                {
                    return NotFound($"The ActorAdress with zipCode: ' {zip} ' was not foud!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }

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
