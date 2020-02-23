using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUI.Models
{
    public class TableViewModel
    {
        public int? Id { get; set; }
        public int PartnerId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
