using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class EmployeeUsers
    {
        [Key]
        public int EmployeeId { get; set; }

        //[ForeignKey("AspNetUsers")]
        public int UserId { get; set; }

        //[ForeignKey("Addresses")]
        public int Address { get; set; }
    }
}