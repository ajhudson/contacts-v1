using ContactManager.Config;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Entities
{
    public class ContactContext : DbContext 
    {
        private IAppSettings appSettings;

        /*
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
            
        }
        */
        public ContactContext(IAppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(appSettings.ConnectionString);
        }
    }
}
