﻿using API.IRepository;
using API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : Controller
    {
        private IGenreRepository _genreRepository;

        //Dependency Injection => atunci cand  este nevoie se instantiaza clasa 
        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        //We will add CRUD action

        //1. GET Method:   api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            var rezult = await _genreRepository.GetGenres();

            return rezult;
        }

        //1. GET Method:   api/Movies/5

        [HttpGet("id")]
        public async Task<ActionResult<Genre>> GetGenreById(Guid id)
        {
           var rezult = await _genreRepository.GetGenreById(id);
            return rezult;
        }

        [HttpGet("name")]
        public async Task<ActionResult<Genre>> GetGenreByName(string name)
        {
            var rezult = await _genreRepository.GetGenreByName(name);
            return rezult;
        }

        //post
        [HttpPost]
        [Authorize]
        /*
        example post API  in Swagger or PostMan
        {
            "GenreName": "Action X2",
            "Movies": []
        }
        */
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            var rezult = await _genreRepository.PostGenre(genre);

            return rezult;
        }

        //PUT
        [HttpPut("{id}")]
        [Authorize]
        /*
         example update API

         */
        public async Task<IActionResult> UpdateGenre(Guid id, Genre genre)
        {
            var rezult = await _genreRepository.UpdateGenre(id, genre);
            return rezult;
        }


        #region "Delete"
        //DELETE
        [HttpDelete("id")]
        //auth
        [Authorize]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            var rezult = await _genreRepository.DeleteGenre(id);

            return rezult;
        }
        #endregion
    }
}
