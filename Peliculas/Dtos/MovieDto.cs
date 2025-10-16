using System.ComponentModel.DataAnnotations;

namespace Peliculas.Dtos
{
    public class MovieDtoIn
    {
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        [MaxLength(256)]
        public string Sinopsis { get; set; }

        public string Encodedkey { get; set; } = Guid.NewGuid().ToString();
    }

    public class MovieDto //: MovieDtoIn
    {
        public string Title { get; set; }

        public string Sinopsis { get; set; }

        public string Encodedkey { get; set; }

        public DateTime Date { get; set; }

        public bool IsWatched { get; set; }
    }
}
