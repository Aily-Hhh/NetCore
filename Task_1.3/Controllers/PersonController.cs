using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Task_1._3.interfaces;
using Task_1._3.Models;

namespace Task_1._3.Controllers
{
    public class PersonController : Controller
    {
        private AccountContext _personContext;

        public PersonController(AccountContext personContext)
        {
            _personContext = personContext;
        }

        public ViewResult List()
        {
            return View(_personContext.People);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            _personContext.People.Add(person);
            _personContext.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _personContext.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var person = _personContext.People.Find(id);
            _personContext.People.Remove(person);
            _personContext.SaveChanges(true);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _personContext.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            _personContext.Entry(person).State = EntityState.Modified;
            _personContext.SaveChanges();
            return RedirectToAction("List");
        }
    }
}