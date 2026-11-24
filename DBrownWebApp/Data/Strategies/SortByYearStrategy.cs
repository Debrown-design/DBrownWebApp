using DBrownWebApp.Data.Models;

namespace DBrownWebApp.Data.Strategies
{
    public class SortByYearStrategy : IMovieSortStrategy
    {
        public string Name => "year";

        public IEnumerable<Movie> Sort(IEnumerable<Movie> movies)
        {
            return movies.OrderBy(movie => movie.Year);
        }
    }
}