using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraveyardManagerWebpage.Models
{
    /// <summary>
    /// Class: Movie
    /// Author: John Kirschner
    /// Date: 09-26-2018
    /// Class Purpose: 
    ///     This class is used to test the model aspect of MVC
    ///     Not to be used on release
    /// </summary>
    [Table("MovieDetails")]
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }

    /// <summary>
    /// Class: MovieDBContext
    /// Author: John Kirschner
    /// Date: 09-26-2018
    /// Class Purpose:
    ///     This class helps represent a collection of movies in a database, please note that System.Data.Entity must be used 
    ///     for this class to work. The EntityFramework DLL can be obtained through the NuGet package manager
    /// </summary>
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}