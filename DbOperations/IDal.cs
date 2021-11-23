using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.DbOperations
{
    public interface IDal<T>
    {
        List<T> Read();
        void Create(T parameter);
        void Delete(int id);
        void Update(T parameter);
        T Find(int id);
    }
}
