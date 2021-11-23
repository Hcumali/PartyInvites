using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyInvites.Models;
using PartyInvites.DbOperations;

namespace PartyInvites.Controllers
{
    public class PartyController : Controller
    {
        IDal<Party> _dal;
        public PartyController(IDal<Party> dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Party> parties = _dal.Read();
            return View(parties);
        }

        [HttpPost]
        public IActionResult Create(Party party)
        {
            if (ModelState.IsValid)
            {
                _dal.Create(party);
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
        public IActionResult Update(Party party)
        {
            if (ModelState.IsValid)
            {
                _dal.Update(party);
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
            Party party = _dal.Find(id);
            return View(party);
        }
    }
}
