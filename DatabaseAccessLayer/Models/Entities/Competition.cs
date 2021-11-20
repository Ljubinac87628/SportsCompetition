using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseAccessLayer
{
    public partial class Competition
    {
        public Competition()
        {
            CompetitionMembers = new HashSet<CompetitionMember>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CompetitionTypeID")]
        public int CompetitionTypeId { get; set; }
        [Column("VenueID")]
        public int VenueId { get; set; }
        [Required]
        [Column("CompetitionOrganizerID")]
        [StringLength(450)]
        public string CompetitionOrganizerId { get; set; }

        [ForeignKey(nameof(CompetitionOrganizerId))]
        [InverseProperty(nameof(AspNetUser.Competitions))]
        public virtual AspNetUser CompetitionOrganizer { get; set; }
        [ForeignKey(nameof(CompetitionTypeId))]
        [InverseProperty("Competitions")]
        public virtual CompetitionType CompetitionType { get; set; }
        [ForeignKey(nameof(VenueId))]
        [InverseProperty("Competitions")]
        public virtual Venue Venue { get; set; }
        [InverseProperty(nameof(CompetitionMember.Competition))]
        public virtual ICollection<CompetitionMember> CompetitionMembers { get; set; }
    }
}
