using System;
using System.Collections.Generic;
using System.Linq;
using PartyInvites.Context;
using PartyInvites.Models;
using PartyInvites.Models.ViewModels;

namespace PartyInvites.DbOperations
{
    public class PartyDal : BaseDal<Party>,IDal<Party>
    {
        CodeFirstContext _db;
        public PartyDal(CodeFirstContext db) : base(db)
        {
            _db = db;
        }

        public override void Delete(int id)
        {
            Party party = _db.Parties.Find(id);
            party.Status = Enums.DataStatus.Deleted;
            party.ModifiedDate = DateTime.Now;
            // Soft Delete for doesnt lose the data
            _db.Parties.Update(party);
            _db.SaveChanges();
        }

        public override void Update(Party party)
        {
            party.Status = Enums.DataStatus.Updated;
            party.ModifiedDate = DateTime.Now;
            _db.Parties.Update(party);
            _db.SaveChanges();
        }

    }
}
