using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel
    {

        public Vidly.Models.Movie movies { get; set; }

        public List<Models.Customer> Customers { get; set; }
    }
}