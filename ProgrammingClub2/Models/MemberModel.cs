﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClub2.Models
{
    public class MemberModel
    {
        public Guid IDMember { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Resume { get; set; }
    }
}