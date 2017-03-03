using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zathura.Admin.CustomFilter;
using Zathura.Core.Infrastructure;
using Zathura.Data.Model;

namespace Zathura.Admin.Controllers
{
    public class ContentController : Controller
    {
        #region Repositories
        private readonly IContentRepository _contentRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMediaItemRepository _mediaItemRepository;

        public ContentController(IContentRepository contentRepository, ICategoryRepository categoryRepository, IUserRepository userRepository, IMediaItemRepository mediaItemRepository)
        {
            _contentRepository = contentRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _mediaItemRepository = mediaItemRepository;
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [LoginFilter]
        public ActionResult Add()
        {
            SetCategoryList();
            return View();
        }

        [HttpPost]
        [LoginFilter]
        public ActionResult Add(Content content, int CategoryID, HttpPostedFileBase spotImage, IEnumerable<HttpPostedFileBase> contentImages)
        {
            var userSession = HttpContext.Session[Core.Helper.Session.User] as User;
            if (ModelState.IsValid) //check Content object attributes is ok?
            {
                var user = _userRepository.GetById(Convert.ToInt32(userSession.ID));
                content.UserID = user.ID;
                content.CategoryID = CategoryID;
                content.StartDate = DateTime.Now;
                if (spotImage != null)
                {
                    string fileName = Guid.NewGuid().ToString().Replace("-", "");
                    string extension = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string fullPath = "/external/content/" + fileName + extension;
                    Request.Files[0].SaveAs(Server.MapPath(fullPath));
                    content.MediaItem = fullPath;
                }
                _contentRepository.Insert(content);
                _contentRepository.Save();
                //get inserted content id and save images if contentImages not null
                string mediaList = System.IO.Path.GetExtension(Request.Files[1].FileName);
                if (contentImages != null)
                {
                    foreach (var file in contentImages)
                    {
                        if (file.ContentLength > 0)
                        {
                            string fileName = Guid.NewGuid().ToString().Replace("-", "");
                            string extension = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string fullPath = "/external/content/" + fileName + extension;
                            file.SaveAs(Server.MapPath(fullPath));

                            var media = new MediaItem
                            {
                                Url = fullPath
                            };

                            media.Content.ID = content.ID;
                            _mediaItemRepository.Insert(media);
                            _mediaItemRepository.Save();
                        }
                    }
                }

            }
            return View();
        }


        #region Set Category List

        public void SetCategoryList(object category = null)
        {
            var categoryList = _categoryRepository.GetMany(x => x.ParentCategoryId == 0).ToList();
            ViewBag.CategoryList = categoryList;
        }

        #endregion
    }
}