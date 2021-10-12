using ProgrammingClub2.Models;
using ProgrammingClub2.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClub2.Repositories
{
    public class CodeSnippetRepository
    {
        private ClubMembershipModelsDataContext dbContext;

        public CodeSnippetRepository()
        {
            this.dbContext = new ClubMembershipModelsDataContext();
        }

        public CodeSnippetRepository(ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private CodeSnippetModel MapDbObjectToModel(CodeSnippet dbCodeSnippet)
        {
            CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
            if (dbCodeSnippet != null)
            {
                codeSnippetModel.IDCodeSnippet = dbCodeSnippet.IDCodeSnippet;
                codeSnippetModel.ContentCode = dbCodeSnippet.ContentCode;
                codeSnippetModel.IDMember = dbCodeSnippet.IDMember;
                codeSnippetModel.Title = dbCodeSnippet.Title;
                codeSnippetModel.Revision = dbCodeSnippet.Revision;
                
                return codeSnippetModel;
            }
            return null;
        }

        internal void InsertMember(CodeSnippetModel codeSnippetModel)
        {
            throw new NotImplementedException();
        }

        private CodeSnippet MapModelToDbObject(CodeSnippetModel codeSnippetModel)
        {
            CodeSnippet codeSnippet = new CodeSnippet();
            if (codeSnippetModel != null)
            {
                codeSnippet.IDCodeSnippet = codeSnippetModel.IDCodeSnippet;
                codeSnippet.ContentCode = codeSnippetModel.ContentCode;
                codeSnippet.IDMember = codeSnippetModel.IDMember;
                codeSnippet.Title = codeSnippetModel.Title;
                codeSnippet.Revision = codeSnippetModel.Revision;
                
                return codeSnippet;
            }
            return null;
        }

        public List<CodeSnippetModel> GetAll()
        {
            List<CodeSnippetModel> codeSnippets = new List<CodeSnippetModel>();
            foreach (CodeSnippet codeSnippet in dbContext.CodeSnippets)
            {
                codeSnippets.Add(MapDbObjectToModel(codeSnippet));
            }
            return codeSnippets;
        }

        public CodeSnippetModel GetById(Guid id)
        {
            return MapDbObjectToModel(dbContext.CodeSnippets.FirstOrDefault(c => c.IDCodeSnippet == id));
        }

        public void InsertCodeSnippet(CodeSnippetModel codeSnippetModel)
        {
            codeSnippetModel.IDCodeSnippet = Guid.NewGuid();
            dbContext.CodeSnippets.InsertOnSubmit(MapModelToDbObject(codeSnippetModel));
            dbContext.SubmitChanges();
        }

        public void UpdateCodeSnippet(CodeSnippetModel codeSnippetModel)
        {
            CodeSnippet codeSnippet = dbContext.CodeSnippets.
                FirstOrDefault(x => x.IDCodeSnippet == codeSnippetModel.IDCodeSnippet);
            if (codeSnippet != null)
            {
                codeSnippet.IDCodeSnippet = codeSnippetModel.IDCodeSnippet;
                codeSnippet.ContentCode = codeSnippetModel.ContentCode;
                codeSnippet.IDMember = codeSnippetModel.IDMember;
                codeSnippet.Title = codeSnippetModel.Title;
                codeSnippet.Revision = codeSnippetModel.Revision;
                dbContext.SubmitChanges();
            }
        }

        public void Delete(Guid id)
        {
            CodeSnippet codeSnippet = dbContext.CodeSnippets.
                FirstOrDefault(c => c.IDCodeSnippet == id);
            if (codeSnippet != null)
            {
                dbContext.CodeSnippets.DeleteOnSubmit(codeSnippet);
                dbContext.SubmitChanges();
            }
        }
    }
}