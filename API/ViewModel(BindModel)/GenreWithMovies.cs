using API.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ViewModel_BindModel_
{
    public class GenreWithMovies
    {

        public string? GenreName { get; set; }
        public ICollection<MovieLinq>? Movies { get; set; }

    }
}
