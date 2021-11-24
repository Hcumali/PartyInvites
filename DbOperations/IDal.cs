using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartyInvites.Models.ViewModels;

namespace PartyInvites.DbOperations
{
    public interface IDal<T> where T : class , new()
    {
        public IQueryable<T> Table { get;} // entity framework => tolist , firstOrDefault(x=>x.id == id)
        List<T> Read();
        void Create(T parameter);
        void Delete(int id);
        void Update(T parameter);
        T Find(int id);
    }
}
