using ContactManager.Config;
using ContactManager.DataModels;
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

        public IActionResult Index()
        {
            IEnumerable<Contact> contacts = contactsRepository.FindAll();
            HomeIndexModel model = new HomeIndexModel
            {
                Contacts = contacts,
                Count = contacts.Count()
            };

            return this.View(model);
        }
    }
}
