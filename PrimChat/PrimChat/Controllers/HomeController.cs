using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimChat.Models;
using System.Data.Entity;

namespace PrimChat.Controllers
{
    
    public class HomeController : Controller
    {
        ChatContext db = new ChatContext();
        public ActionResult Index()
        {
            IEnumerable<User> Users = db.Users;
            ViewBag.Users = Users;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            User usr = db.Users.Find(id);
            if (usr != null)
            {
                return View(usr);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddUser(int id)
        {
            ViewBag.head = "Добавление пользователя";
            return View();
        }
        [HttpPost]
        public string AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return "Добавлен " + user.mat;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            User usr = db.Users.Find(id);
            if (usr == null)
            {
                return HttpNotFound();
            }
            return View(usr);
        }

        [HttpPost, ActionName("Delete")]        
        public ActionResult DeleteConfirmed(int id)
        {
            User usr = db.Users.Find(id);
            if (usr == null)
            {
                return HttpNotFound();
            }
            db.Users.Remove(usr);
            db.SaveChanges();
            return RedirectToAction("Index");            
        }
        
    }
}