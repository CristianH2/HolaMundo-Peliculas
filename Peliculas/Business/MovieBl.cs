using Peliculas.Contexts;
using Peliculas.Core;
using Peliculas.Dtos;
using Peliculas.Entities;

namespace Peliculas.Business
{
    public class MovieBl
    {
        private readonly IMovieRepository _movieRepository;

        public MovieBl(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDto> GetMovieAsync(int movieId)
        {
            var dto = new MovieDto();
            MovieEntity entity = await _movieRepository.GetMovieAsync(movieId);

            if (entity == null)
            {
                return null;
            }

            dto = new MovieDto
            {
                Title = entity.Title,
                Sinopsis = entity.Sinopsis,
                Date = entity.Date,
                Encodedkey = entity.Encodedkey,
                IsWatched = entity.IsWatched
            };

            return dto;
        }

        public async Task<List<MovieDto>> GetMoviesAsync()
        {
            List<MovieEntity> entities;
            List<MovieDto> dtos;

            entities = await _movieRepository.GetMoviesAsync();
            dtos = entities.Select(x => new MovieDto
            {
                Date = x.Date,
                Encodedkey = x.Encodedkey,
                IsWatched = x.IsWatched,
                Sinopsis = x.Sinopsis,
                Title = x.Title,
            }).ToList();

            return dtos;
        }

        public async Task<bool> UpdateAsync(int movieId, MovieDtoIn movie)
        {
            MovieEntity entity = await _movieRepository.GetMovieAsync(movieId);

            if (entity == null)
            {
                return false;
            }

            entity.Title = movie.Title;
            entity.Sinopsis = movie.Sinopsis;
            entity.Encodedkey = movie.Encodedkey;

            await _movieRepository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int movieId)
        {
            var entity = await _movieRepository.GetMovieAsync(movieId);

            if (entity == null)
            {
                return false;
            }

            await _movieRepository.DeleteAsync(movieId);
            return true;
        }

        public async Task<int> AddAsync(MovieDtoIn movie)
        {
            int id;
            MovieEntity entity;

            entity = new MovieEntity
            {
                Encodedkey = movie.Encodedkey,
                Sinopsis = movie.Sinopsis,
                Title = movie.Title
            };
            id = await _movieRepository.AddAsync(entity);

            return id;
        }
    }
}
