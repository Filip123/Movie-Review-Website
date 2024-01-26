using System;
using System.Text.Json;

namespace MovieReview.Models
{
	public class Movie
	{
		public int Id { get; set; }

		public String Name { get; set; }
		public String Year { get; set; }
		public int Rating { get; set; }


        public override string ToString() => JsonSerializer.Serialize<Movie>(this);
        
        public Movie()
		{
		}
	}
}

