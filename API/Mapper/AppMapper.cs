using API.Model;
using API.ModelsDTO.ActorAdrDto;
using API.ModelsDTO.ActorDto;
using API.ModelsDTO.GenreDto;
using API.ModelsDTO.MovieDto;

namespace API.Mapper
{
    public class AppMapper : AutoMapper.Profile
    {
        public AppMapper()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Genre, GenreWithMovieDTO>().ReverseMap();
            CreateMap<Genre, UpdateGenreDTO>().ReverseMap();

            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<Actor, ActorAndAdressDTO>().ReverseMap();

            CreateMap<ActorAdress, ActorAdressDTO>().ReverseMap();
            CreateMap<ActorAdress, InsertActorAdressWithActorID>().ReverseMap();
            CreateMap<ActorAdress, UpdateActorAdressDTO>().ReverseMap();

            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Movie, MoviesWithDetailsDTO>().ReverseMap();
            CreateMap<Movie, InsertMovieDTO>().ReverseMap();
            CreateMap<Movie, UpdateMovieDTO>().ReverseMap();
        }
    }
}
