using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models.ViewModels
{
    public class UserCreateForm
    {
        public User User { get; set; }
        public UserDetail UserDetail { get; set; }

        public int PartyId { get; set; }
        public List<Party> Parties { get; set; }
    }
}
