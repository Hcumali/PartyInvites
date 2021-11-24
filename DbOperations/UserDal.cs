using System;
using System.Collections.Generic;
using System.Linq;
using PartyInvites.Context;
using PartyInvites.Models;
using PartyInvites.Models.ViewModels;

namespace PartyInvites.DbOperations
{
    public class UserDal : BaseDal<User>, IDal<User>
    {
        CodeFirstContext _db;
        public UserDal(CodeFirstContext db) : base(db)
        {
            _db = db;
        }
    }
}
