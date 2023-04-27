﻿using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<GenreSong> Songs { get; set; }
    }
}
