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

        //[ForeignKey("CustomerId")]
        [Display(Name = "Customer")]
        public CustomerUsers CustomerId { get; set; }

        [Required]
        public int Address { get; set; }

        [Required]
        [Display(Name = "Pick Up Day")]
        public DayOfWeek PickUpDay { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public bool Recurring { get; set; }
    }
}