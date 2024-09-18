using AuthSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Models;

namespace UserManagementSystem.Controllers
{
    [Authorize]
    [Route("userlist")]
    public class UserlistController : Controller
    {
        private readonly AuthDbContext _db;

        public UserlistController(AuthDbContext db)
        {
            _db = db;
        }

        [Route("")]
        public IActionResult Index()
        {
            List<UserList> userLists = _db.UserLists.ToList();
            return View(userLists);
        }

        [Route("details/{id:int}")]
        public IActionResult Details(int? id)
        {
            UserList? userList = _db.UserLists.Find(id);
            if (id == null || id == 0 || userList == null)
            {
                return NotFound();
            }
            return View(userList);
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("create")]
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

        [Route("edit/{id:int}")]
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
        [Route("edit/{id:int}")]
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

        [Route("delete/{id:int}")]
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
