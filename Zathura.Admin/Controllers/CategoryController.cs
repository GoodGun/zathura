using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zathura.Core.Infrastructure;
using Zathura.Data.Model;

namespace Zathura.Admin.Controllers
{
    public class CategoryController : Controller
    {
        #region Category
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(Category category)
        {
            return Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}