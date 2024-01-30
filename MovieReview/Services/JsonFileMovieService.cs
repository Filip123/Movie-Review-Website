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

		public IWebHostEnvironment WebHostEnvironment { get; }

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

		public void AddRating(String movieId, int rating)
		{
			var movies = GetMovies();

			var query = movies.First(x => x.Id == movieId);

			if (query.Ratings == null)
			{
				//Create new raings array with rating in
				query.Ratings = new int[] { rating };
			}
			else
			{
				var tempRatings = query.Ratings.ToList();
				tempRatings.Add(rating);
				query.Ratings = tempRatings.ToArray();

			}

			//Serialize raings and add to json file

			using (var outputStream = File.OpenWrite(JsonFileName))
			{
				JsonSerializer.Serialize<IEnumerable<Movie>>(
					new Utf8JsonWriter(outputStream, new JsonWriterOptions
					{
						SkipValidation = true,
						Indented = true
					}),
					movies
					);
			}
		}

	}
}

