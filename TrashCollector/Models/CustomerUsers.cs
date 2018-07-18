using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace TrashCollector.Models
{
    public class CustomerUsers
    {
        [Key]
        public int CustomerId { get; set; }

        //[ForeignKey("Id")]
        public string UserId { get; set; }

        //fk
        public IdentityRole Role { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //[ForeignKey ("Addresses")]
        public int Address { get; set; }

        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }




    }
}