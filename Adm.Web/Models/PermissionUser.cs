using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Adm.Web.Models
{
    [Table("PermissionUser")]
    public class PermissionUser
    {
        [Key]
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public Permission Permission { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
