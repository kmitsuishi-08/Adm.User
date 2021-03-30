using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adm.Web.Models
{
    [Table("User")]
    public class User
    {
        [Key] // PK
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [Range(1,99)]
        public int Age { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        public bool IsEnabled { get; set; }

        public ICollection<PermissionUser> PermissionUsers { get; set; }

    }
}
