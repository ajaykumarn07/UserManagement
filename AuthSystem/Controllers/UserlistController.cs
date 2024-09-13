using AuthSystem.Data;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Models;

namespace UserManagementSystem.Controllers
{
    public class UserlistController : Controller
    {
        private readonly AuthDbContext _db;

        public UserlistController(AuthDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<UserList> userLists = _db.UserLists.ToList();
            return View(userLists);
        }

        public IActionResult Details(int? id)
        {
            UserList? userList = _db.UserLists.Find(id);
            if (id == null || id == 0 || userList == null)
            {
                return NotFound();
            }
            return View(userList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserList userList)
        {
            if (_db.UserLists.Any(u => u.Email!.Equals(userList.Email)))
            {
                ModelState.AddModelError("Email", "E-Mail already exists!");
            }
            if (ModelState.IsValid)
            {
                _db.UserLists.Add(userList);
                _db.SaveChanges();

                TempData["success"] = "User Created Successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            UserList? userList = _db.UserLists.Find(id);
            if (id == null || id == 0 || userList == null)
            {
                return NotFound();
            }
            return View(userList);
        }

        [HttpPost]
        public IActionResult Edit(UserList userList)
        {
            if (_db.UserLists.Any(u => u.Email!.Equals(userList.Email) && u.Id != userList.Id))
            {
                ModelState.AddModelError("Email", "E-Mail already exists!");
            }
            if (ModelState.IsValid)
            {            
                _db.UserLists.Update(userList);
                _db.SaveChanges();

                TempData["success"] = "User Edited Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            UserList? userList = _db.UserLists.Find(id);
            if (id == null || id == 0 || userList == null)
            {
                return NotFound();
            }
            _db.UserLists.Remove(userList);
            _db.SaveChanges();
            TempData["success"] = "User Deleted Successfully";

            return RedirectToAction("Index");
        }
    }
}
