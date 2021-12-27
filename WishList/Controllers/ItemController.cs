using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext appCtxt)
        {
            _context = appCtxt;
        }
        public IActionResult Index()
        {
            List<Item> itemList = new List<Item>();
            foreach (var it in _context.Items)
            {
                itemList.Add(it);
            }
            
            return View("Index", itemList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index", "Item");
        }
        public IActionResult Delete(int Id)
        {
            Item it = new Item();
            it.Id = Id;
            _context.Remove(it);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Item");
        }
    }
}
