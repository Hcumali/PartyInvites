using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartyInvites.Models
{
    public class UserDetail : BaseEntity
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public bool WillAttend { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]

        public virtual User User { get; set; }
    }
}
