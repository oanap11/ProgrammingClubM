using ProgrammingClub2.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClub2.Models.ViewModels
{
    public class MemberCodeSnippetViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public List<CodeSnippetModel> CodeSnippets = new List<CodeSnippetModel>();
    }
}