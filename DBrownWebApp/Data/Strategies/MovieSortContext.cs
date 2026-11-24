using DBrownWebApp.Data.Models;

namespace DBrownWebApp.Data.Strategies
{
    public class MovieSortContext
    {
        private readonly Dictionary<string, IMovieSortStrategy> _strategies;

        public MovieSortContext(IEnumerable<IMovieSortStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(
                strategy => strategy.Name,
                StringComparer.OrdinalIgnoreCase);
        }

        public IEnumerable<Movie> Sort(
            IEnumerable<Movie> movies,
            string? strategyName)
        {
            if (string.IsNullOrWhiteSpace(strategyName) ||
                !_strategies.TryGetValue(strategyName, out IMovieSortStrategy? strategy))
            {
                strategy = _strategies["title"];
            }

            return strategy.Sort(movies);
        }
    }
}