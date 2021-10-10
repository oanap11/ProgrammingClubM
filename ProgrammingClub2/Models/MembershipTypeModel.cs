using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammingClub2.Models
{
    public class MembershipTypeModel
    {
        public Guid IDMembershipType { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        public int SubscriptionLengthInMonths { get; set; }
    }
}