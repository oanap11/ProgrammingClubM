using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingClub2.Models;
using ProgrammingClub2.Models.DBObjects;
using ProgrammingClub2.Repositories;
using ProgrammingClubM.Repositories;

namespace ProgrammingClub2.Tests.Repository
{
    [TestClass]
    public class AnnouncementRepositoryTest
    {
        private ClubMembershipModelsDataContext dbContext;
        private string testConnectionString;
        private AnnouncementRepository announcementRepository;

        [TestInitialize]
        public void Initialize()
        {
            testConnectionString = ConfigurationManager.ConnectionStrings["clubmembershipConnectionStringTest"]
                .ConnectionString;
            dbContext = new ClubMembershipModelsDataContext(testConnectionString);
            announcementRepository = new AnnouncementRepository(dbContext);
        }

        [TestMethod]
        public void GetAnnouncementById_AnnouncementsExists()
        {
            ///AAA-> Arrange, Act, Assert

            //Arrange
            Guid ID = Guid.NewGuid();
            Announcement expectedAnnouncement = new Announcement
            {
                IDAnnouncement = ID,
                ValidFrom = new DateTime(2021, 1, 1),
                ValidTo = new DateTime(2021, 1, 1),
                Tags = "test tag",
                Text = "Announcement",
                Title = "Important",
                EventDateTime = null
            };
            dbContext.Announcements.InsertOnSubmit(expectedAnnouncement);
            dbContext.SubmitChanges();

            //Act
            AnnouncementModel result = announcementRepository.GetAnnouncementById(ID);

            //Assert
            Assert.AreEqual(result.IDAnnouncement, expectedAnnouncement.IDAnnouncement);
            Assert.AreEqual(result.Title, expectedAnnouncement.Title);
            Assert.AreEqual(result.Text, expectedAnnouncement.Text);
            Assert.AreEqual(result.Tags, expectedAnnouncement.Tags);
            Assert.AreEqual(result.ValidFrom, expectedAnnouncement.ValidFrom);
            Assert.AreEqual(result.ValidTo, expectedAnnouncement.ValidTo);
        }

        [TestMethod]
        public void GetAnnouncementById_AnnouncementDoesntExist()
        {
            //Arrange
            Guid ID = Guid.NewGuid();
            Announcement expectedAnnouncement = new Announcement
            {
                IDAnnouncement = ID,
                ValidFrom = new DateTime(2021, 1, 1),
                ValidTo = new DateTime(2021, 1, 1),
                Tags = "test tag",
                Text = "Announcement",
                Title = "Important",
                EventDateTime = null
            };
            dbContext.Announcements.InsertOnSubmit(expectedAnnouncement);
            dbContext.SubmitChanges();

            //Act
            AnnouncementModel result = announcementRepository.GetAnnouncementById(Guid.NewGuid());

            Assert.IsNull(result);

        }
    }
}
