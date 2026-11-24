using DBrownWebApp.Data.Models;

namespace DBrownWebApp.Data.Strategies
{
    public interface IMovieSortStrategy
    {
        string Name { get; }

        IEnumerable<Movie> Sort(IEnumerable<Movie> movies);
    }
}