using ProgrammingClub2.Models;
using ProgrammingClub2.Models.DBObjects;
using ProgrammingClub2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClub2.Repositories
{
    public class MemberRepository
    {
        //injectare container ORM
        private Models.DBObjects.ClubMembershipModelsDataContext dbContext;

        public MemberRepository()
        {
            this.dbContext = new Models.DBObjects.ClubMembershipModelsDataContext();
        }

        public MemberRepository(Models.DBObjects.ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public MemberCodeSnippetViewModel GetMemberCodeSnippets(Guid memberID)
        {
            MemberCodeSnippetViewModel memberCodeSnippetViewModel = new MemberCodeSnippetViewModel();
            Member member = dbContext.Members.FirstOrDefault(m => m.IDMember == memberID);

            if(member != null)
            {
                memberCodeSnippetViewModel.Name = member.Name;
                memberCodeSnippetViewModel.Position = member.Position;
                memberCodeSnippetViewModel.Title = member.Title;

                IQueryable<CodeSnippet> memberCodeSnippets = dbContext.CodeSnippets.Where(c => c.IDMember == memberID);
                foreach(CodeSnippet code in memberCodeSnippets)
                {
                    CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
                    codeSnippetModel.Title = code.Title;
                    codeSnippetModel.ContentCode = code.ContentCode;
                    codeSnippetModel.Revision = code.Revision;
                    memberCodeSnippetViewModel.CodeSnippets.Add(codeSnippetModel);
                }
            }
            return memberCodeSnippetViewModel;
        }

        public List<MemberModel> GetAllMembers()
        {
            List<MemberModel> memberList = new List<MemberModel>();
            foreach (Models.DBObjects.Member dbMember in dbContext.Members)
            {
                memberList.Add(MapDbObjectToModel(dbMember));
            }
            return memberList;
        }

        public MemberModel GetMemberByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Members.FirstOrDefault(m => m.IDMember == ID));
        }

        public void InsertMember(MemberModel memberModel)
        {
            memberModel.IDMember = Guid.NewGuid(); 
            dbContext.Members.InsertOnSubmit(MapModelToDbObject(memberModel));
            dbContext.SubmitChanges(); 
        }

        public void UpdateMember(MemberModel memberModel)
        {
            Models.DBObjects.Member existingMember = dbContext.Members.FirstOrDefault(m => m.IDMember == memberModel.IDMember);
            if (existingMember != null)
            {
                existingMember.IDMember = memberModel.IDMember;
                existingMember.Name = memberModel.Name;
                existingMember.Title = memberModel.Title;
                existingMember.Position = memberModel.Position;
                existingMember.Description = memberModel.Description;
                existingMember.Resume = memberModel.Resume;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteMember(Guid ID)
        {
            Models.DBObjects.Member memberToDelete = dbContext.Members.FirstOrDefault(m => m.IDMember == ID);
            if (memberToDelete != null)
            {
                dbContext.Members.DeleteOnSubmit(memberToDelete); 
                dbContext.SubmitChanges(); 
            }
        }

        private MemberModel MapDbObjectToModel(Member member)
        {
            MemberModel memberModel = new MemberModel();
            if (member != null)
            {
                memberModel.IDMember = member.IDMember;
                memberModel.Name = member.Name;
                memberModel.Title = member.Title;
                memberModel.Position = member.Position;
                memberModel.Description = member.Description;
                memberModel.Resume = member.Resume;
            
                return memberModel;
            }
            return null;
        }

        private Member MapModelToDbObject(MemberModel memberModel)
        {
            Member dbMember = new Member();
            if (memberModel != null)
            {
                dbMember.IDMember = memberModel.IDMember;
                dbMember.Name = memberModel.Name;
                dbMember.Title = memberModel.Title;
                dbMember.Position = memberModel.Position;
                dbMember.Description = memberModel.Description;
                dbMember.Resume = memberModel.Resume;
                return dbMember;
            }
            return null;
        }




    }
}