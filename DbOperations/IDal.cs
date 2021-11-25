using System.Collections.Generic;
using System.Linq;

namespace PartyInvites.DbOperations
{
    public interface IDal<T> where T : class , new()
    {
        List<T> Read();
        void Create(T parameter);
        void Delete(int id);
        void Update(T parameter);
        T Find(int id);
        List<T> GetSearchedData(string search = "");

    }
}
