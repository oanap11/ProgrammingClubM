using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammingClub2.Models
{
    public class MemberModel
    {
        public Guid IDMember { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "The string is too long(max 50)")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "The string is too long(max 50)")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        public string Resume { get; set; }
    }
}