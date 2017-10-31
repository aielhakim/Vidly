using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        //[Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Required]
        //[Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1, 20)]
        //[Display(Name = "Number in Stock")]
        public string NumberInStock { get; set; }
    }
}