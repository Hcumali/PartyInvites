using System;
using System.Collections.Generic;
using System.Linq;
using PartyInvites.Context;
using PartyInvites.Models;

namespace PartyInvites.DbOperations
{
    public class CategoryDal : IDal<Category>
    {
        CodeFirstContext _db;
        public CategoryDal(CodeFirstContext db)
        {
            _db = db;
        }


        public List<Category> Read()
        {
            List<Category> categories = _db.Categories.Where(x => x.Status != Enums.DataStatus.Deleted).ToList();
            return categories;
        }

        public void Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = _db.Categories.Find(id);
            category.Status = Enums.DataStatus.Deleted;
            category.ModifiedDate = DateTime.Now;
            // Soft Delete for doesnt lose the data
            _db.Categories.Update(category);
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            category.Status = Enums.DataStatus.Updated;
            category.ModifiedDate = DateTime.Now;
            _db.Categories.Update(category);
            _db.SaveChanges();
        }

        public Category Find(int id)
        {
            Category category = _db.Categories.Find(id);
            return category;
        }

    }
}
