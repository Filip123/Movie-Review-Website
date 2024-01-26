using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieReview.Models;
using MovieReview.Services;

namespace MovieReview.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public JsonFileMovieService MovieService;

    public IEnumerable<Movie> Movies { get; private set; }

    public IndexModel(ILogger<IndexModel> logger,
        JsonFileMovieService movieService) //I need some stuff, go get it
    {
        _logger = logger;
        MovieService = movieService;
    }

    public void OnGet()
    {
        Movies = MovieService.GetMovies();
    }
}

