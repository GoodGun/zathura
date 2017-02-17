using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Zathura.Core.Infrastructure;
using Zathura.Data.DataContext;
using Zathura.Data.Model;

namespace Zathura.Core.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly ZathuraContext _context = new ZathuraContext();
        public int Count()
        {
            return _context.Images.Count();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Images.Remove(item);
            }
        }

        public Image Get(Expression<Func<Image, bool>> expression)
        {
            return _context.Images.FirstOrDefault(expression);
        }

        public IEnumerable<Image> GetAll()
        {
            return _context.Images.Select(x => x);
        }

        public Image GetById(int id)
        {
            return _context.Images.FirstOrDefault(x => x.ImageId == id);
        }

        public IQueryable<Image> GetMany(Expression<Func<Image, bool>> expression)
        {
            return _context.Images.Where(expression);
        }

        public void Insert(Image obj)
        {
            _context.Images.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Image obj)
        {
            _context.Images.AddOrUpdate();
        }
    }
}
