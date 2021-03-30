using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleDockerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDockerProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IRepository<Movie> _repository;
        public MovieController(IRepository<Movie> repository)
        {
            _repository = repository;
        }
        // GET: api/<MovieController>
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var movies = _repository.GetItems();
            if (movies.Count() == 0)
            {
                return BadRequest("No movies are added till now");
            }
            else
            {
                return Ok(movies);
            }
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = _repository.GetItemsById(id);
            if (movie == null)
            {
                return BadRequest("Movie not found");
            }
            else
            {
                return Ok(movie);
            }
        }

        // POST api/<MovieController>
        [HttpPost]
        public ActionResult Post([FromBody] Movie movie)
        {
            try
            {
                _repository.AddItem(movie);
                return Ok("Movie added");
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
