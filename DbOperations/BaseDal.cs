using Microsoft.EntityFrameworkCore;
using PartyInvites.Context;
using System.Collections.Generic;
using System.Linq;

namespace PartyInvites.DbOperations
{
    public class BaseDal<T> : IDal<T> where T : class, new()
    {
        private readonly CodeFirstContext _dal;
        private readonly DbSet<T> _setEntity;
        public BaseDal(CodeFirstContext dal)
        {
            _dal = dal;
            _setEntity = _dal.Set<T>();

        }

        public virtual void Create(T parameter)
        {
            _setEntity.Add(parameter);
            _dal.SaveChanges();
        }
        public virtual List<T> Read()
        {
            return _setEntity.ToList();
        }

        public virtual T Find(int id)
        {
            return _setEntity.Find(id);
        }

        public virtual void Delete(int id)
        {
            var deletedEntity = _setEntity.Find(id);
            _setEntity.Remove(deletedEntity);
            _dal.SaveChanges();
        }

        public virtual void Update(T parameter)
        {
            _setEntity.Update(parameter);
            _dal.SaveChanges();
        }

        public virtual List<T> GetSearchedData(string search = "")
        {
            throw new System.NotImplementedException();
        }
    }
}
