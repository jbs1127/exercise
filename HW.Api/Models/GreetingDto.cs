using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW.Api.Models
{
    public class GreetingDto
    {
        public int GreetingId { get; set; }

        [Required]
        [StringLength(1000)]
        public string GreetingText { get; set; }
    }
}