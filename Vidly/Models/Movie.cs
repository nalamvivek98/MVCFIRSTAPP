using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public GenreType GenreType { get; set; }
        [ForeignKey("GenreType")]
        [Required]
        [Display(Name = "Genre")]
        public int GenreType_Id { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? Releasedate { get; set; }
        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        [Required]
        [Display(Name = "Number in Stock")]
        public int No_in_stock { get; set; }
       
    }
}