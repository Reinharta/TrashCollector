using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Cities
    {
        [Key]
        public string Id { get; set; }

        [Display(Name = "City")]
        public string CityName { get; set; }
    }
}