using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyInvites.Context;
using PartyInvites.DbOperations;
using PartyInvites.Models;
using PartyInvites.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
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
            // The ViewComponent in this view
            return View();
        }

        [HttpPost]
        public IActionResult Search(string searchWord)
        {
            var results = _dal.GetSearchedData(searchWord);
            return View("Index", results);
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
        public IActionResult Create(int? partyId)
        {
            List<Party> parties = _dal1.Read();
            UserCreateForm userCreateForm = new UserCreateForm() { Parties = parties };
            if (partyId.HasValue)
            {
                userCreateForm.PartyId = partyId.Value;
            }
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










