using API.Model;
using API.ModelDTO;

namespace API.Mapper
{
    public class AppMapper : AutoMapper.Profile
    {
        public AppMapper()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<ActorAdress, ActorAdressDTO>().ReverseMap();

            CreateMap<Movie, MoviesWithActorsDTO>().ReverseMap();
        }
    }
}
