using API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace API.ModelDTO
{
    public class MovieDTO
    { 
        public string? Title { get; set; }
        public DateTime ReleseDate { get; set; }

        //consturctor => make the linq shorter
        public MovieDTO(Movie movie)
        {
            Title = movie.Title;
            ReleseDate = movie.RealeseDate;
        }
    }
}
