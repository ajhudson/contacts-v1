using ContactManager.Config;
using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private IAppSettings appSettings;
        private IRepository<Contact> contactsRepository;

        public HomeController(IAppSettings appSettings, IRepository<Contact> contactsRepository)
        {
            this.appSettings = appSettings;
            this.contactsRepository = contactsRepository;
        }

        /*
        public string Index()
        {
            Contact billy = new Contact
            {
                FirstName = "Billy",
                Surname = "Nomates",
                EmailAddress = "billy.nomates@gmail.com"
            };

            Contact cara = new Contact
            {
                FirstName = "Cara",
                Surname = "Hudson",
                EmailAddress = "cara@gmail.com"
            };

            contactsRepository.Add(billy);
            contactsRepository.Add(cara);

            return "Hello from a controller. There are " + contactsRepository.Count;
        }
        */

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
