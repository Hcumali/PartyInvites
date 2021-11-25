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

        public override void Delete(int id)
        {
            User user = _db.Users.Find(id);
            user.Status = Enums.DataStatus.Deleted;
            user.ModifiedDate = DateTime.Now;
            // Soft Delete for doesnt lose the data
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public override void Update(User user)
        {
            user.Status = Enums.DataStatus.Updated;
            user.ModifiedDate = DateTime.Now;
            _db.Users.Update(user);
            _db.SaveChanges();
        }

    }
}
