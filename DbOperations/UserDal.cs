using System;
using System.Collections.Generic;
using System.Linq;
using PartyInvites.Context;
using PartyInvites.Models;

namespace PartyInvites.DbOperations
{
    public class UserDal : IDal<User>
    {
        CodeFirstContext _db;
        public UserDal(CodeFirstContext db)
        {
            _db = db;
        }

        public List<User> Read()
        {
            List<User> users = _db.Users.ToList();
            return users;
        }

        public void Create(User user)
        {
            _db.Users.Add(user);
            // detail add
            //_db.UserDetails.Add(user.UserDetail)

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = _db.Users.Find(id);
            user.Status = Enums.DataStatus.Deleted;
            user.ModifiedDate = DateTime.Now;
            // Soft Delete for doesnt lose the data
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void Update(User user)
        {
            user.Status = Enums.DataStatus.Updated;
            user.ModifiedDate = DateTime.Now;
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public User Find(int id)
        {
            User party = _db.Users.Find(id);
            return party;
        }
    }
}
