using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zathura.Admin.Helper;
using Zathura.Core.Infrastructure;
using Zathura.Data.Model;
using PagedList;

namespace Zathura.Admin.Controllers
{
    public class CategoryController : Controller
    {
        #region Primitives

        public const int PagingCount = 20;
        #endregion

        #region Category
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion
        // GET: Category
        public ActionResult Index(int p=1)
        {
            return View(_categoryRepository.GetAll().OrderByDescending(x => x.CategoryId).ToPagedList(p, PagingCount));
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

        #region Delete Category
        public ActionResult Delete(int categoryId)
        {
            var category = _categoryRepository.GetById(categoryId);
            if (category == null)
            {
                return Json(new ResultJson { Success = false, Message = "Category couldn't found!" });
            }
            _categoryRepository.Delete(categoryId);
            _categoryRepository.Save();
            return Json(new ResultJson { Success = true, Message = "Category deleted successfully..." });
        }
        #endregion


    }
}