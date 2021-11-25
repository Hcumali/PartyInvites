using System;
using System.Collections.Generic;
using System.Linq;
using PartyInvites.Context;
using PartyInvites.Models;
using PartyInvites.Models.ViewModels;
using PartyInvites.Enums;
using Microsoft.EntityFrameworkCore;

namespace PartyInvites.DbOperations
{
    public class UserDal : BaseDal<User>, IDal<User>
    {
        CodeFirstContext _db;
        public UserDal(CodeFirstContext db) : base(db)
        {
            _db = db;
        }

        public override List<User> Read()
        {
            List<User> users = _db.Users.Where(user => user.Status != Enums.DataStatus.Deleted).Include(x => x.UserDetail).Include(x => x.Party).ToList();
            return users;
        }

        
        public override List<User> GetSearchedData(string search)
        {
            var searchWord = search.ToLower();


            var results = _db.Users.Where(x => 
                                        x.UserName.ToLower().Contains(searchWord) ||
                                        x.Role.
                                       // x.UserDetail.Email.ToLower().Contains(searchWord) || 
                                       // x.UserDetail.Phone.Contains(searchWord) || 
                                        //x.UserDetail.Age.ToString() == searchWord|| 
                                        //x.Party.PartyName.ToLower().Contains(searchWord)
                                        )
                                    .Where(user => user.Status != Enums.DataStatus.Deleted)
                                    .Include(x => x.UserDetail).Include(x => x.Party).ToList();
            return results;
        }

        private string EnumParser(string word)
        {
            if(word == "manager")
            {
                return "1";
            }
            return "2";
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
