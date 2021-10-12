using ProgrammingClub2.Models;
using ProgrammingClub2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClub2.Controllers
{
    [Authorize(Roles = "Admin, User, Visitor")]
    public class CodeSnippetController : Controller
    {
        CodeSnippetRepository codeSnippetRepository = new CodeSnippetRepository();

        // GET: CodeSnippet
        public ActionResult Index()
        {
            List<CodeSnippetModel> codeSnippets = codeSnippetRepository.GetAll();
            return View("Index", codeSnippets);
        }

        // GET: CodeSnippet/Details/5
        public ActionResult Details(Guid id)
        {
            CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetById(id);
            return View("DetailsCodeSnippet", codeSnippetModel);
        }

        // GET: CodeSnippet/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: CodeSnippet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
                UpdateModel(codeSnippetModel);
                codeSnippetRepository.InsertCodeSnippet(codeSnippetModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: CodeSnippet/Edit/5
        public ActionResult Edit(Guid id)
        {
            CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetById(id);
            return View("EditCodeSnippet", codeSnippetModel);
        }

        // POST: CodeSnippet/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
                UpdateModel(codeSnippetModel);
                codeSnippetRepository.UpdateCodeSnippet(codeSnippetModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditCodeSnippet");
            }
        }

        // GET: CodeSnippet/Delete/5
        public ActionResult Delete(Guid id)
        {
            CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetById(id);
            return View("DeleteCodeSnippet", codeSnippetModel);
        }

        // POST: CodeSnippet/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                codeSnippetRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteCodeSnippet");
            }
        }
    }
}
