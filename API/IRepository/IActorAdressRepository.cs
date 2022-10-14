﻿using API.Model;
using API.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.IRepository
{
    public interface IActorAdressRepository
    {
        Task<IEnumerable<ActorAdress>> GetActorAdress();
        Task<ActorAdress> GetActorAdressById(Guid id);
        Task<ActorAdress> GetActorAdressByZipCode(int zipcode);
        Task<ActionResult<ActorAdress>> PostActorAdress(ActorAdress actorAdress);
        Task<IActionResult> UpdateActorAdress(Guid id, ActorAdress actorAdress);
        Task<IActionResult> DeleteActorAdress(Guid id);
    }
}
