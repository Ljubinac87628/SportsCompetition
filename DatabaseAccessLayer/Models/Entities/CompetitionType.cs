using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseAccessLayer
{
    public partial class CompetitionType
    {
        public CompetitionType()
        {
            Competitions = new HashSet<Competition>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [InverseProperty(nameof(Competition.CompetitionType))]
        public virtual ICollection<Competition> Competitions { get; set; }
    }
}
