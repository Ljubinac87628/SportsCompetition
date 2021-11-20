using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseAccessLayer
{
    public partial class Venue
    {
        public Venue()
        {
            Competitions = new HashSet<Competition>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        [Column("CountryID")]
        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Venues")]
        public virtual Country Country { get; set; }
        [InverseProperty(nameof(Competition.Venue))]
        public virtual ICollection<Competition> Competitions { get; set; }
    }
}
