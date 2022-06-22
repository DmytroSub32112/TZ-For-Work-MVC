using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebTestForWork3.Models;
using WebTestForWork3.Repa;

namespace WebTestForWork3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateOrders(string name, string nameorders, int price, int quantity)
        {
            MyRepa.MapCreate(name,nameorders, price, quantity);
            return View("Index");
        }
        public IActionResult GetOrders()
        {
           var models = MyRepa.MapGet();
            var sortcol = new string[] { "Name", "Id","Date","Amount" };
            var col2 = new SelectList(sortcol, sortcol[1]);
            ViewBag.SelectItems = col2;
            return View(models);
        }
        [HttpPost]
        public IActionResult GetOrders(string str)
        {
            var models = MyRepa.MapSort(str);         
            var sortcol = new string[] { "Name", "Id", "Date", "Amount" };
            var col2 = new SelectList(sortcol, sortcol[1]);
            ViewBag.SelectItems = col2;
            return View(models);
        }
        public IActionResult DeleteOrders()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteOrders(int number)
        {
            MyRepa.MapDeleteForNumber(number);
            return View("DeleteOrders");
        }
        public IActionResult UpdateOrders()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateOrders(int Id, string positionName, int price, int quantity)
        {
            MyRepa.MapUpdate(Id, positionName, price, quantity);
            return View();
        }
        public IActionResult AddPosition()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPosition(int Id, string name, int price, int quantity)
        {
            MyRepa.MapAddPosition(Id, name, price, quantity);
            return View();
        }
    }
}
