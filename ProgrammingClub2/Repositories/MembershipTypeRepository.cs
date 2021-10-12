using ProgrammingClub2.Models;
using ProgrammingClub2.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClub2.Repositories
{
    public class MembershipTypeRepository
    {
        private ClubMembershipModelsDataContext dbContext;

        public MembershipTypeRepository()
        {
            this.dbContext = new ClubMembershipModelsDataContext();
        }

        public MembershipTypeRepository(ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void InsertMembershipType(MembershipTypeModel membershipTypeModel)
        {
            membershipTypeModel.IDMembershipType = Guid.NewGuid();
            dbContext.MembershipTypes.InsertOnSubmit(MapModelToDbObject(membershipTypeModel));
            dbContext.SubmitChanges();
        }

        public MembershipTypeModel GetMembershipTypeByID(Guid id)
        {
            return MapDbObjectToModel(dbContext.MembershipTypes.FirstOrDefault(ann => ann.IDMembershipType == id));
        }

        public List<MembershipTypeModel> GetAllMembershipTypes()
        {
            List<MembershipTypeModel> membershipTypeLists = new List<MembershipTypeModel>();
            foreach (var dbMembershipType in dbContext.MembershipTypes)
            {
                membershipTypeLists.Add(MapDbObjectToModel(dbMembershipType));
            }
            return membershipTypeLists;
        }

        public void UpdateMembershipType(MembershipTypeModel membershipTypeModel)
        {
            MembershipType existingMembershipType = dbContext.MembershipTypes.
                FirstOrDefault(x => x.IDMembershipType == membershipTypeModel.IDMembershipType);
            if (existingMembershipType != null)
            {
                existingMembershipType.IDMembershipType = membershipTypeModel.IDMembershipType;
                existingMembershipType.Name = membershipTypeModel.Name;
                existingMembershipType.Description = membershipTypeModel.Description;
                existingMembershipType.SubscriptionLengthMonths = membershipTypeModel.SubscriptionLengthMonths;

                dbContext.SubmitChanges();
            }
        }

        public void DeleteMembershipType(Guid id)
        {
            MembershipType membershipTypeToBeDeleted = dbContext.MembershipTypes.
                FirstOrDefault(ann => ann.IDMembershipType == id);
            if (membershipTypeToBeDeleted != null)
            {
                dbContext.MembershipTypes.DeleteOnSubmit(membershipTypeToBeDeleted);
                dbContext.SubmitChanges();
            }
        }

        private MembershipTypeModel MapDbObjectToModel(MembershipType membershipType)
        {
            MembershipTypeModel membershipTypeModel = new MembershipTypeModel();
            if (membershipType != null)
            {
                membershipTypeModel.IDMembershipType = membershipType.IDMembershipType;
                membershipTypeModel.Name = membershipType.Name;
                membershipTypeModel.Description = membershipType.Description;
                membershipTypeModel.SubscriptionLengthMonths = membershipType.SubscriptionLengthMonths;

                return membershipTypeModel;
            }
            return null;
        }

        private MembershipType MapModelToDbObject(MembershipTypeModel membershipTypeModel)
        {
            MembershipType dbMembershipType = new MembershipType();
            if (membershipTypeModel != null)
            {
                dbMembershipType.IDMembershipType = membershipTypeModel.IDMembershipType;
                dbMembershipType.Name = membershipTypeModel.Name;
                dbMembershipType.Description = membershipTypeModel.Description;
                dbMembershipType.SubscriptionLengthMonths = membershipTypeModel.SubscriptionLengthMonths;

                return dbMembershipType;
            }
            return null;
        }
    }
}