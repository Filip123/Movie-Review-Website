using System;
using System.Text.Json;
using MovieReview.Models;


namespace MovieReview.Services
{
	public class JsonFileMovieService
	{
		public JsonFileMovieService(IWebHostEnvironment webHostEnvironment)
		{
			WebHostEnvironment = webHostEnvironment;
		}

		public IWebHostEnvironment WebHostEnvironment{get;}

		private string JsonFileName
		{
			get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "movies.json"); }
		}

		public IEnumerable<Movie> GetMovies()
		{
			using (var jsonFileReader = File.OpenText(JsonFileName))
			{
				return JsonSerializer.Deserialize<Movie[]>(jsonFileReader.ReadToEnd(),
					new JsonSerializerOptions
                    {
						PropertyNameCaseInsensitive = true
					});
			}
        }
	}

}

