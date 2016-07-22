using ContactManager.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class HomeIndexModel
    {
        public IEnumerable<Contact> Contacts { get; set; }

        public int Count { get; set; }
    }
}
