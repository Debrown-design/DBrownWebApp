using DBrownWebApp.Data.Models;

namespace DBrownWebApp.Data.Strategies
{
    public class SortByTitleStrategy : IMovieSortStrategy
    {
        public string Name => "title";

        public IEnumerable<Movie> Sort(IEnumerable<Movie> movies)
        {
            return movies.OrderBy(movie => movie.Title);
        }
    }
}