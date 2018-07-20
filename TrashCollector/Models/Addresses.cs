using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Addresses
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        //Foreign Key
        public int State { get; set; }

        public int Zipcode { get; set; }

        
    }
}