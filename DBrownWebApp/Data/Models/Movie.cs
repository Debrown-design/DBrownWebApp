using System.ComponentModel.DataAnnotations;

namespace DBrownWebApp.Data.Models
{
    public class Movie
    {
        private static int _nextId = 100;
        public int Id { get; set; } = _nextId++;

        [Required]
        public string Title { get; set; }
        [Range(1888, 2025)]
        public int? Year { get; set; } = null;
        [Range(0.0f, 9.99f)]
        public float Score { get; set; }

        public override string ToString()
        {
            return $"{Title} ({Year}) - {Score}/10";
        }
    }
}
