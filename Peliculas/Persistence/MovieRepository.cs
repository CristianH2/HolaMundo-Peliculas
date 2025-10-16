using Microsoft.EntityFrameworkCore;
using Peliculas.Contexts;
using Peliculas.Core;
using Peliculas.Entities;

namespace Peliculas.Persistence
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _appDbContext;

        public MovieRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<int> AddAsync(MovieEntity movieEntity)
        {
            _appDbContext.Movie.Add(movieEntity);
            await _appDbContext.SaveChangesAsync();

            return movieEntity.Id;
        }

        public async Task<List<MovieEntity>> GetMoviesAsync()
        => await _appDbContext.Movie.Where(x => x.IsActivate == true).ToListAsync();



        public async Task<MovieEntity> GetMovieAsync(int movieId)
        {
            MovieEntity? movie = new MovieEntity();
            movie = await _appDbContext.Movie
                            .FirstOrDefaultAsync(m => m.Id == movieId && m.IsActivate == true);
            return movie;
        }

        public async Task UpdateAsync(MovieEntity movieEntity)
        {
            _appDbContext.Entry(movieEntity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int movieId)
        {
            var movieEntity = await GetMovieAsync(movieId);

            if (movieEntity != null)
            {
                _appDbContext.Movie.Remove(movieEntity);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
