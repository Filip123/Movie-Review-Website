using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Services;

namespace MovieReview.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesController(JsonFileMovieService movieService)
        {
 
        }

        public JsonFileMovieService MovieService { get; }
    }
}
