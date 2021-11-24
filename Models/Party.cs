using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PartyInvites.Enums;

namespace PartyInvites.Models
{
    public class Party : BaseEntity
    {
        [Required(ErrorMessage = "Parti adı boş girilemez.")]
        [StringLength(35, ErrorMessage = "Parti adı 35 haneden fazla olamaz.")]
        public string PartyName { get; set; }

        [Required(ErrorMessage = "Parti tarihi boş girilemez.")]
        public DateTime PartyDate { get; set; }

        [Required(ErrorMessage = "Parti tipi boş girilemez.")]
        public PartyType PartyType { get; set; }

        [Required(ErrorMessage = "Bilet ücreti boş girilemez.")]
        public int TicketPrice { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
