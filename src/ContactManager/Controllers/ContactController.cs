using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Services;
using ContactManager.DataModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {
        private readonly IRepository<Contact> contactsRepo;

        public ContactController(IRepository<Contact> contactsRepo)
        {
            this.contactsRepo = contactsRepo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact newContact)
        {
            if (!ModelState.IsValid)
            {
                return View(newContact);
            }

            contactsRepo.Add(newContact);
            return RedirectToAction("Index", "Home");
        }
    }
}
