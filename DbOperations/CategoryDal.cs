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

        public override List<Category> Read()
        {
            List<Category> categories = _db.Categories.Where(category => category.Status != Enums.DataStatus.Deleted).ToList();
            return categories;
        }

        public override void Delete(int id)
        {
            Category category = _db.Categories.Find(id);
            category.Status = Enums.DataStatus.Deleted;
            category.ModifiedDate = DateTime.Now;
            // Soft Delete for doesnt lose the data
            _db.Categories.Update(category);
            _db.SaveChanges();
        }

        public override void Update(Category category)
        {
            category.Status = Enums.DataStatus.Updated;
            category.ModifiedDate = DateTime.Now;
            _db.Categories.Update(category);
            _db.SaveChanges();
        }

    }
}
