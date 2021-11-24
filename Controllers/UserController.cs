using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyInvites.Context;
using PartyInvites.DbOperations;
using PartyInvites.Models;
using PartyInvites.Models.ViewModels;

namespace PartyInvites.Controllers
{
    public class UserController : Controller
    {
        IDal<User> _dal;
        IDal<Party> _dal1;

        public UserController(IDal<User> dal, IDal<Party> dal1)
        {
            _dal = dal;
            _dal1 = dal1;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<User> users = _dal.Read();
            return View(users);
        }

        [HttpPost]
        public IActionResult Create(UserCreateForm userCreateForm)
        {
            if (ModelState.IsValid)
            {
                var user = new User 
                { 
                    UserName = userCreateForm.User.UserName,
                    Role = userCreateForm.User.Role,
                    PartyId = userCreateForm.PartyId,
                    UserDetail = userCreateForm.UserDetail,
                
                };
                _dal.Create(user);
                return RedirectToAction("Index");
            }
            else
            {
                userCreateForm.Parties = _dal1.Read();
                return View(userCreateForm);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Varolan parti listesini dropdownda sıralamak için..
            // .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = x.PartyName, Text = x.PartyName}).ToList()
            List<Party> parties = _dal1.Read();
            UserCreateForm userCreateForm = new UserCreateForm() { Parties = parties };
            return View(userCreateForm);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _dal.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                _dal.Update(user);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            User user = _dal.Find(id);
            return View(user);
        }


    }
}










