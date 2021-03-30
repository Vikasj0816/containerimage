using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDockerProject.Models
{
    public class MoviesRepository:IRepository<Movie>
    {
        List<Movie> movies;
        private MoviesRepository repository = null;
        public MoviesRepository()
        {
            movies = new List<Movie>();
            movies.Add(new Movie
            {
                Id = 1,
                Name = "Robert",
                Duration = 123.3f
            });
        }
        public void AddItem(Movie movie)
        {
            this.movies.Add(movie);
        }
        public IEnumerable<Movie> GetItems()
        {
            return this.movies;
        }
        public Movie GetItemsById(int id)
        {
            return this.movies.FirstOrDefault(x => x.Id == id);
        }
    }
}
