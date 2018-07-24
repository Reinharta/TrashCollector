using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TrashCollector.Models;

namespace TrashCollector.Models
{
    public class Billing
    {
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey("PickUps")]
        public int PickUpId { get; set; }
        public PickUps PickUps { get; set; }

        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public CustomerUsers Customers { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PickUpDate { get; set; }

        public double Fee { get; set; }

        public bool Paid { get; set; }

    }
}