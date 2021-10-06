﻿using Company.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWoning.Controllers
{
    public class WoningController : Controller
    {
        WoningRepo _repo;
        List<Models.Woning> _woningen;
        public WoningController()
        {
            _repo = new WoningRepo();
            _woningen = new List<Models.Woning>();


        }

        private void GetBewonersAndWoningen(List<Woning> woningen)
        {
            foreach(var item in woningen)
            {
                var wn = new Models.Woning();
                wn.Naam = item.Naam;
                wn.Id = item.ID;
                item.Bewoners.ForEach(b => wn.Bewoners
                .Add(new Models.Bewoner()
                {
                    Naam = b.Naam
                }));
                _woningen.Add(wn);
            }
        }

        // GET: WoningController
        public ActionResult Index()
        {
            _repo = new WoningRepo();
            _woningen = new List<Models.Woning>();
            var woningen = _repo.GetAll();
            GetBewonersAndWoningen(woningen);
            return View(_woningen);
        }

        // GET: WoningController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WoningController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WoningController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WoningController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WoningController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WoningController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WoningController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}