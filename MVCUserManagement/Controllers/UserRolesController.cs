using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVCUserManagement.Abstractions;
using MVCUserManagement.Abstractions.Repositories;
using MVCUserManagement.Models;
using MVCUserManagement.Persistence.Context;

namespace MVCUserManagement.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly UserManagementDbContext _context = new UserManagementDbContext();
        private readonly IUserRolesRepository _repository = new UserRolesRepository();


        [HttpGet]
        public async Task<ActionResult> ListRoles()
        {
            return View(await _context.UserRoles.ToListAsync());
        }



        [HttpGet]
        public async Task<ActionResult> AddRole()
        {
            return await Task.Run(() => View());
        }


        [HttpPost]
        public async Task<ActionResult> AddRole(UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.CreateRoleAsync(userRole);
                }
                catch (Exception ex) 
                {
                    throw new Exception($"Failed to create role. See exception details: {ex}");
                }

                return RedirectToAction("ListRoles");
            }

            return View(userRole);
        }
    }
}











//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web.Mvc;
//using MVCUserManagement.Models;
//using MVCUserManagement.Persistence.Context;

//namespace MVCUserManagement.Controllers
//{
//    public class UserRolesController : Controller
//    {
//        private UserManagementDbContext db = new UserManagementDbContext();

//        // GET: UserRoles
//        public ActionResult Index()
//        {
//            return View(db.UserRoles.ToList());
//        }

//        // GET: UserRoles/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserRole userRole = db.UserRoles.Find(id);
//            if (userRole == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userRole);
//        }

//        // GET: UserRoles/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: UserRoles/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "RoleId,RoleName,RoleDescription")] UserRole userRole)
//        {
//            if (ModelState.IsValid)
//            {
//                db.UserRoles.Add(userRole);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(userRole);
//        }

//        // GET: UserRoles/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserRole userRole = db.UserRoles.Find(id);
//            if (userRole == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userRole);
//        }

//        // POST: UserRoles/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "RoleId,RoleName,RoleDescription")] UserRole userRole)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(userRole).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(userRole);
//        }

//        // GET: UserRoles/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserRole userRole = db.UserRoles.Find(id);
//            if (userRole == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userRole);
//        }

//        // POST: UserRoles/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            UserRole userRole = db.UserRoles.Find(id);
//            db.UserRoles.Remove(userRole);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
