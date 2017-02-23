using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zathura.Admin.Helper;
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

        #region Add Category
        [HttpGet]
        public ActionResult Add()
        {
            var parentCatList = _categoryRepository.GetMany(x => x.ParentCategoryId == 0 && x.IsActive).ToList();
            ViewBag.ParentCategoryList = parentCatList;
            return View();
        }

        [HttpPost]
        public JsonResult Add(Category category)
        {
            try
            {
                _categoryRepository.Insert(category);
                _categoryRepository.Save();
                return Json(new ResultJson() { Success = true, Message = "Category Added Successfully." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "Category couldnt added!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }
        }
        #endregion
    }
}