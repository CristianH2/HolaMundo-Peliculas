using System.ComponentModel.DataAnnotations;

namespace Peliculas.Entities
{
    public class MovieEntity
    {
        public int Id { get; set; }

        [MaxLength(128)]
        public string Title { get; set; }

        [MaxLength(256)]
        public string Sinopsis { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Encodedkey { get; set; } = Guid.NewGuid().ToString();

        public bool IsWatched { get; set; } = false;

        public bool IsActivate { get; set; } = true;
    }
}
