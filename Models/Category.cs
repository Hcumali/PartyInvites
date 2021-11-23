using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartyInvites.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Cannot be empty")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        public string Description { get; set; }
    }
}
