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
    public class ContentRepository : IContentRepository
    {
        private readonly ZathuraContext _context = new ZathuraContext();
        public int Count()
        {
            return _context.Contents.Count();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Contents.Remove(item);
            }
        }

        public Content Get(Expression<Func<Content, bool>> expression)
        {
            return _context.Contents.FirstOrDefault(expression);
        }

        public IEnumerable<Content> GetAll()
        {
            return _context.Contents.Select(x => x);
        }

        public Content GetById(int id)
        {
            return _context.Contents.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Content> GetMany(Expression<Func<Content, bool>> expression)
        {
            return _context.Contents.Where(expression);
        }

        public void Insert(Content obj)
        {
            _context.Contents.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Content obj)
        {
            _context.Contents.AddOrUpdate();
        }
    }
}
