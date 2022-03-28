using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Task_1._3.interfaces;
using Task_1._3.Models;

namespace Task_1._3.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPerson _people;

        public PersonController(IPerson people) 
        {
            _people = people; 
        }

        public ViewResult List()
        {
            var allPeople = _people.People;
            return View(allPeople);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var allPeople = _people.People;
            SelectList teams = new SelectList(allPeople, "Id", "Name", "Age");
            ViewBag.Teams = teams;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            return RedirectToAction("List");
        }
    }
}