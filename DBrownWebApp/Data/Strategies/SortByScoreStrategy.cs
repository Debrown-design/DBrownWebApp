using DBrownWebApp.Data.Models;

namespace DBrownWebApp.Data.Strategies
{
    public class SortByScoreStrategy : IMovieSortStrategy
    {
        public string Name => "score";

        public IEnumerable<Movie> Sort(IEnumerable<Movie> movies)
        {
            return movies.OrderByDescending(movie => movie.Score);
        }
    }
}