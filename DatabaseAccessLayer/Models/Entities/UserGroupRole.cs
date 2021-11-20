using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseAccessLayer
{
    public partial class UserGroupRole
    {
        [Key]
        public string RoleId { get; set; }
        [Key]
        public int UserGroupId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(AspNetRole.UserGroupRoles))]
        public virtual AspNetRole Role { get; set; }
        [ForeignKey(nameof(UserGroupId))]
        [InverseProperty("UserGroupRoles")]
        public virtual UserGroup UserGroup { get; set; }
    }
}
