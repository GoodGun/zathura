using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zathura.Admin.Helper;
using Zathura.Core.Infrastructure;
using Zathura.Data.Model;
using PagedList;
using Zathura.Admin.CustomFilter;
using Zathura.Core.Helper;

namespace Zathura.Admin.Controllers
{
    public class CategoryController : Controller
    {
        #region Primitives
        private const int PagingCount = 3;
        #endregion

        #region Category
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion

        #region Index
        [HttpGet]
        public ActionResult Index(int p = 1)
        {
            return View(_categoryRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(p, PagingCount));
        }
        #endregion

        #region Add Category
        [HttpGet]
        public ActionResult Add()
        {
            var parentCatList = _categoryRepository.GetMany(x => x.ParentCategoryId == 0 && x.Status == (int)Status.Active).ToList();
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

        #region Update Category
        [HttpGet]
        [LoginFilter]
        public ActionResult Update(int categoryId)
        {
            var category = _categoryRepository.GetById(categoryId);
            if (category == null)
            {
                throw new Exception("Category couldn't found!");
            }
            var parentCatList = _categoryRepository.GetMany(x => x.ParentCategoryId == 0 && x.Status == (int)Status.Active).ToList();
            ViewBag.ParentCategoryList = parentCatList;
            return View(category);
        }

        [HttpPost]
        [LoginFilter]
        public JsonResult Update(Category category)
        {
            //if (ModelState.IsValid)
            //{
                var categoryItem = _categoryRepository.GetById(category.ID);
                categoryItem.Status = category.Status;
                categoryItem.Name = category.Name;
                categoryItem.ParentCategoryId = category.ParentCategoryId;
                categoryItem.Url = category.Url;
                _categoryRepository.Save();
                return Json(new ResultJson {Success = true, Message = "Category updated successfully."});
            //}
            //return Json(new ResultJson { Success = false, Message = "Category couldn't updated!" });
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