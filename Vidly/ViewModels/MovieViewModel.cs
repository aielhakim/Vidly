using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public List<Models.Genre> Genres { get; set; }

        public Models.Movie Movie { get; set; }
    }
}