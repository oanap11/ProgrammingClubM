﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammingClub2.Models
{
    public class AnnouncementModel
    {
        public Guid IDAnnouncement { get; set; }
        [Required(ErrorMessage="Mandatory field")]
        public DateTime ValidFrom { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        public DateTime ValidTo { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage ="The string is too long(max 50)")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "The string is too long(max 250)")]
        public string Text { get; set; }
        public DateTime? EventDateTime { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(50, ErrorMessage = "The string is too long(max 50)")]
        public string Tags { get; set; }
    }
}