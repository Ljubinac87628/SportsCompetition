using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseAccessLayer
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            UserGroupRoles = new HashSet<UserGroupRole>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [InverseProperty(nameof(UserGroupRole.UserGroup))]
        public virtual ICollection<UserGroupRole> UserGroupRoles { get; set; }
    }
}
