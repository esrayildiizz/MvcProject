﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        // GET: Writer
        public ActionResult Index()
        {
            var Writervalues = wm.GetList();
            return View(Writervalues);
            
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue = wm.GetByID( id);
            return View(writervalue);
        }


        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }
    }
}