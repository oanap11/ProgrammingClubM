﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClub2.Models
{
    public class MembershipTypeModel
    {
        public Guid IDMembershipType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubscriptionLengthInMonths { get; set; }
    }
}