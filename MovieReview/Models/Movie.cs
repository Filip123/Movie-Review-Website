using System;
using System.Text.Json;

namespace MovieReview.Models
{
	public class Movie
	{
		public String Id { get; set; } 
		public String Name { get; set; }
		public String Year { get; set; }
		public String Img { get; set; }
		public int[] Ratings { get; set; }


        public override string ToString() => JsonSerializer.Serialize<Movie>(this);
        
        public Movie()
		{
		}
	}
}

