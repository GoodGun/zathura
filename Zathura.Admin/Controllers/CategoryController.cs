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
using Zathura.Core.Repository;

namespace Zathura.Admin.Controllers
{
    public class CategoryController : Controller
    {
        #region Primitives
        private const int PagingCount = 30;
        #endregion

        #region Category & SystemSettings
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISystemSettingRepository _systemSettingRepository;

        public CategoryController() : this(new CategoryRepository(), new SystemSettingRepository())
        {
              
        }

        public CategoryController(ICategoryRepository categoryRepository, ISystemSettingRepository systemSettingRepository)
        {
            _categoryRepository = categoryRepository;
            _systemSettingRepository = systemSettingRepository;
        }
        #endregion
        

        #region MyRegion

        
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
            var systemSettingsList = _systemSettingRepository.GetMany(x => x.Key == "Status").ToList();
            ViewBag.StatusList = systemSettingsList;
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
                //var user = Session["User"] as User;
                //if (user != null)
                //{
                //    var usr = new User();
                //    usr = user;
                //    category.User = usr;
                //    _categoryRepository.Insert(category);
                //    _categoryRepository.Save();
                //    return Json(new ResultJson() { Success = true, Message = "Category Added Successfully." });
                //}
                //return Json(new ResultJson { Success = false, Message = "Category couldnt added!!!"});

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
        public ActionResult Update(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new Exception("Category couldn't found!");
            }
            var parentCatList = _categoryRepository.GetMany(x => x.ParentCategoryId == 0 && x.Status == (int)Status.Active).ToList();
            ViewBag.ParentCategoryList = parentCatList;
            var systemSettingsList = _systemSettingRepository.GetMany(x => x.Key == "Status").ToList();
            ViewBag.StatusList = systemSettingsList;
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