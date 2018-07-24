using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PickUps
    {
        [Key]
        public int PickUpId { get; set; }

        [ForeignKey("Customers")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public CustomerUsers Customers { get; set; }

        [Display(Name ="Street Address")]
        public string StreetAddress { get; set; }

        public int Zipcode { get; set; }

        [Display(Name = "Pick Up Day")]
        public DayOfWeek PickUpDay { get; set; }

        [Display(Name = "Pick Up Date")]
        [DisplayFormat(DataFormatString = "{0:mm/DD/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PickUpDate { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:mm/DD/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:mm/DD/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public bool Recurring { get; set; }
        
        public bool Completed { get; set; }
    }
}