using ProgrammingClub2.Models;
using ProgrammingClub2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClub2.Controllers
{
    public class MembershipTypeController : Controller
    {
        private MembershipTypeRepository membershipTypeRepository = new MembershipTypeRepository();
        // GET: MembershipType
        public ActionResult Index()
        {
            List<MembershipTypeModel> membershipTypes = membershipTypeRepository.GetAllMembershipTypes();
            return View("Index", membershipTypes);
        }

        // GET: MembershipType/Details/5
        public ActionResult Details(Guid id)
        {
            MembershipTypeModel membershipTypeModel = membershipTypeRepository.GetMembershipTypeByID(id);
            return View("DetailsMembershipType", membershipTypeModel);
        }

        // GET: MembershipType/Create
        public ActionResult Create()
        {
            return View("CreateMembershipType");
        }

        // POST: MembershipType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //instantiere model
                MembershipTypeModel membershipTypeModel = new MembershipTypeModel();

                //incarcare date in model
                UpdateModel(membershipTypeModel);

                //apelare resursa care salveaza datele
                membershipTypeRepository.InsertMembershipType(membershipTypeModel);

                //redirectare catre index in caz de succes :D
                return RedirectToAction("Index");
            }
            catch
            {
                //redirectare catre view-ul curent in caz de erori :(
                return View("CreateMembershipType");
            }
        }

        // GET: MembershipType/Edit/5
        public ActionResult Edit(Guid id)
        {
            MembershipTypeModel membershipTypeModel = membershipTypeRepository.GetMembershipTypeByID(id);
            return View("EditMembershipModel", membershipTypeModel);
        }

        // POST: MembershipType/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                MembershipTypeModel membershipTypeModel = new MembershipTypeModel();
                UpdateModel(membershipTypeModel);
                membershipTypeRepository.UpdateMembershipType(membershipTypeModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditMembershipModel");
            }
        }

        // GET: MembershipType/Delete/5
        public ActionResult Delete(Guid id)
        {
            MembershipTypeModel membershipTypeModel = membershipTypeRepository.GetMembershipTypeByID(id);
            return View("DeleteMembershipType", membershipTypeModel);
        }

        // POST: MembershipType/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                membershipTypeRepository.DeleteMembershipType(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteMembershipType");
            }
        }
    }
}
