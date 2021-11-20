using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseAccessLayer
{
    public partial class Country
    {
        public Country()
        {
            Venues = new HashSet<Venue>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [InverseProperty(nameof(Venue.Country))]
        public virtual ICollection<Venue> Venues { get; set; }
    }
}
