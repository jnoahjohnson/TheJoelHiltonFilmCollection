using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheJoelHiltonFilmCollection.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }

        [DisplayName("Lent To")]
        public string LentTo { get; set; }
        [StringLength(25, ErrorMessage ="Notes are limited to 25 characters.")]
        public string Notes { get; set; }
    }
}
