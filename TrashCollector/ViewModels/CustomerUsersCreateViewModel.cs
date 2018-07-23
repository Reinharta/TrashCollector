using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrashCollector.Models;

namespace TrashCollector.ViewModels
{
    public class CustomerUsersCreateViewModel
    {
        public CustomerUsers Customer { get; set; }
        public ApplicationUser AppUser { get; set; }
    }
}