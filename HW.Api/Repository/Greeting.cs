using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HW.Api.Repository
{
    public class Greeting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GreetingId { get; set; }

        [StringLength(1000)]
        public string GreetingText { get; set; }

    }
}