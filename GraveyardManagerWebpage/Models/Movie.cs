using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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
    public class Movie
    {
        public int ID;
        public string Title;
        public DateTime ReleaseDate;
        public string Genre;
        public decimal Price;
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
        public DbSet<Movie> Movies;
    }
}