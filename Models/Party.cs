using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyInvites.Enums;

namespace PartyInvites.Models
{
    public class Party : BaseEntity
    {
        public string PartyName { get; set; }
        public DateTime PartyDate { get; set; }
        public PartyType PartyType { get; set; }
        public int? TicketPrice { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
