using System;
using System.Collections.Generic;
using System.Linq;
using PartyInvites.Context;
using PartyInvites.Models;
using PartyInvites.Models.ViewModels;

namespace PartyInvites.DbOperations
{
    public class CategoryDal : BaseDal<Category>, IDal<Category>
    {
        CodeFirstContext _db;
        public CategoryDal(CodeFirstContext db) : base(db)
        {
            _db = db;
        }
    }
}
