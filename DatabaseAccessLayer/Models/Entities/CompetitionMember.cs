using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseAccessLayer
{
    public partial class CompetitionMember
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CompetitionID")]
        public int CompetitionId { get; set; }
        [Required]
        [Column("MemberID")]
        [StringLength(450)]
        public string MemberId { get; set; }

        [ForeignKey(nameof(CompetitionId))]
        [InverseProperty("CompetitionMembers")]
        public virtual Competition Competition { get; set; }
        [ForeignKey(nameof(MemberId))]
        [InverseProperty(nameof(AspNetUser.CompetitionMembers))]
        public virtual AspNetUser Member { get; set; }
    }
}
