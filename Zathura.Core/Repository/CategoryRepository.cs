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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ZathuraContext _context = new ZathuraContext();
        public int Count()
        {
            return _context.Categories.Count();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Categories.Remove(item);
            }
        }

        public Category Get(Expression<Func<Category, bool>> expression)
        {
            return _context.Categories.FirstOrDefault(expression);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.Select(x => x);
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryId == id);
        }

        public IQueryable<Category> GetMany(Expression<Func<Category, bool>> expression)
        {
            return _context.Categories.Where(expression);
        }

        public void Insert(Category obj)
        {
            _context.Categories.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category obj)
        {
            _context.Categories.AddOrUpdate();
        }
    }
}
