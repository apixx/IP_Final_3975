using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IP_Final_3975.Models
{
    public partial class Sport
    {
        public Sport()
        {
            Players = new HashSet<Players>();
        }

        [Key]
        public int SportId { get; set; }
        public string SportName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Players> Players { get; set; }
    }
}
