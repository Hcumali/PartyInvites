using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyInvites.Context;
using PartyInvites.Models;
using PartyInvites.DbOperations;

namespace PartyInvites.Controllers
{
    public class CategoryController : Controller
    {
        IDal<Category> _dal;
        public CategoryController(IDal<Category> dal)
        {
            _dal = dal;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = _dal.Read();
            return View(categories);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _dal.Create(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _dal.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                _dal.Update(category);
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
            Category category = _dal.Find(id);
            return View(category);
        }
    }
}
