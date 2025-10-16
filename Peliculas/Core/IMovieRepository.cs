using Peliculas.Entities;

namespace Peliculas.Core
{
    public interface IMovieRepository
    {
        Task<int> AddAsync(MovieEntity movieEntity);
        Task DeleteAsync(int movieId);
        Task<MovieEntity> GetMovieAsync(int movieId);
        Task<List<MovieEntity>> GetMoviesAsync();
        Task UpdateAsync(MovieEntity movieEntity);
    }
}
