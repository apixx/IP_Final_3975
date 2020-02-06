using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IP_Final_3975.Models
{
    public partial class Players
    {
        [Key]
        public int PlayerId { get; set; }
        public string FullName { get; set; }
        public int? FkSportId { get; set; }
        public int? Age { get; set; }
        public string Country { get; set; }
        
        public virtual Sport FkSport { get; set; }
    }
}
