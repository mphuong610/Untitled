using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Untitled.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productDAO = new ProductDAO();

            ViewBag.NewProducts = productDAO.ListNewProduct(4);
            ViewBag.ListFeatureProducts = productDAO.ListFeatureProduct(4);

            return View();
        }
    }
}