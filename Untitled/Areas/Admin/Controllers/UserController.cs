using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Untitled.Common;
using PagedList;

namespace Untitled.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDAO();

            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (User user)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDAO();

                var encryptedMd5Pass = Encryptor.MD5Hash(user.PassWord);
                user.PassWord = encryptedMd5Pass;

                long id = dao.Insert(user);
                if(id > 0)
                {
                    SetAlert("Thêm thành công!", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công!");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();

                if(!string.IsNullOrEmpty(user.PassWord))
                {
                    var encryptedMd5Pass = Encryptor.MD5Hash(user.PassWord);
                    user.PassWord = encryptedMd5Pass;
                }
                
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi cập nhật!");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDAO().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}