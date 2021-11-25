using System.Collections.Generic;
using System.Linq;

namespace PartyInvites.DbOperations
{
    public interface IDal<T> where T : class , new()
    {
        public IQueryable<T> Table { get;} 
        List<T> Read();
        void Create(T parameter);
        void Delete(int id);
        void Update(T parameter);
        T Find(int id);
    }
}
