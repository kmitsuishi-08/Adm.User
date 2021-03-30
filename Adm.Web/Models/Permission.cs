using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Adm.Web.Models
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public bool IsEnabled { get; set; }

        public ICollection<PermissionUser> PermissionUsers { get; set; }
    }
}
