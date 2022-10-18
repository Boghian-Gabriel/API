namespace API.ModelsDTO
{
    public class GenreWithMovieDTO : GenreDTO
    {
        public ICollection<MovieDTO>? Movies { get; set; }
    }
}
