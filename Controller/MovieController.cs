using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserInfosApi.DbContext;
using UserInfosApi.Model;
using UserInfosApi.Repository;

namespace UserInfosApi.Controller;

[ApiController]
[Route("api/movies/[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieRepository _movieRepository;

    public MovieController(MovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpGet]
    public ActionResult GetMovies()
    {
        var movies = _movieRepository.GetAllMovies();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
        var movie = _movieRepository.GetMovieById(id);
        if (movie == null) return NotFound();
        
        return Ok(movie);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Movie movie)
    {
        _movieRepository.AddMovie(movie);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, [FromBody] Movie movie)
    {
        movie.Id = id;
        _movieRepository.UpdateMovie(movie);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _movieRepository.DeleteMovie(id);
        return Ok();
    }
}