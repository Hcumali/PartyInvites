using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using PartyInvites.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.ViewComponents
{
    public class UsersTableViewComponent:ViewComponent
    {
        IDal<User> _dal;
        public UsersTableViewComponent(IDal<User> dal)
        {
            _dal=dal;
        }

        public IViewComponentResult Invoke()
        {
            List<User> Users = _dal.Read();
            return View(Users);
        }
    }
}
