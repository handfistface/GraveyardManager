using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GraveyardCommon;

namespace GraveyardManagerWebpage.Models
{
    [Table("Plots")]
    public class PlotDB
    {
        [Key]
        public int ID { get; set; }
        public int PersonId;        //the autogen'd person id number
        [Display(Name="Section")]
        public string Section;      //the section which the grave is contained in
        [Display(Name ="Section ID")]
        public string SectionId;        //the ID of the section
        public bool Ashes;       //whether if the person is ashes
        public int RectX;       //X origin of a rectangle
        public int RectY;       //Y origin of a rectangle
        public int RectWidth;       //width of a rectangle
        public int RectHeight;      //height of a rectangle
    }

    /// <summary>
    /// Class PlotDBContext
    /// Author: John Kirschner
    /// Date: 10-04-2018
    /// Class Purpose:
    ///     This class represents a graveyard in a database.
    ///     The System.Data.Entity is obtained from the EntityFramework from NuGet
    /// </summary>
    public class PlotDBContext : DbContext
    {
        public DbSet<PlotDB> graves { get; set; }
    }
}