using DBrownWebApp.Data.Models;

namespace DBrownWebApp.Data.DAL
{
    public interface IMovieDal
    {
        IEnumerable<Movie> GetAllMovies();
        void addMovie(Movie movie);
    }
}
