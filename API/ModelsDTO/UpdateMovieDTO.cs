namespace API.ModelsDTO
{
    public class UpdateMovieDTO
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime RealeseDate { get; set; }
        public Guid IdRefGenre { get; set; }
    }
}
