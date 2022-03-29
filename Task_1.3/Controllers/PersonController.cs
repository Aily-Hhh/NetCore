using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Task_1._3.interfaces;
using Task_1._3.Models;

namespace Task_1._3.Controllers
{
    public class PersonController : Controller
    {
        private PersonContext _personContext;

        public PersonController(PersonContext personContext) 
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
    }
}