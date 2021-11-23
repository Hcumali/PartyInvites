using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyInvites.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartyInvites.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public Role Role { get; set; }

        public virtual UserDetail UserDetail { get; set; }
        public int PartyId { get; set; }
        [ForeignKey("PartyId")]
        public virtual Party Party { get; set; }
    }
}
