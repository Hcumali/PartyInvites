using System;
using System.Collections.Generic;
using System.Linq;
using PartyInvites.Context;
using PartyInvites.Models;
using PartyInvites.Models.ViewModels;

namespace PartyInvites.DbOperations
{
    public class PartyDal : IDal<Party>
    {
        CodeFirstContext _db;
        public PartyDal(CodeFirstContext db)
        {
            _db = db;
        }


        public List<Party> Read()
        {
            List<Party> parties = _db.Parties.ToList();
            return parties;
        }

        public void Create(Party party)
        {
            _db.Parties.Add(party);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Party party = _db.Parties.Find(id);
            party.Status = Enums.DataStatus.Deleted;
            party.ModifiedDate = DateTime.Now;
            // Soft Delete for doesnt lose the data
            _db.Parties.Update(party);
            _db.SaveChanges();
        }

        public void Update(Party party)
        {
            party.Status = Enums.DataStatus.Updated;
            party.ModifiedDate = DateTime.Now;
            _db.Parties.Update(party);
            _db.SaveChanges();
        }

        public Party Find(int id)
        {
            Party party = _db.Parties.Find(id);
            return party;
        }

        public void Create(UserCreateForm userCreateForm)
        {
            throw new NotImplementedException();
        }
    }
}
