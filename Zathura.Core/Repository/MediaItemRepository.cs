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
    public class MediaItemRepository : IMediaItemRepository
    {
        private readonly ZathuraContext _context = new ZathuraContext();
        public int Count()
        {
            return _context.MediaItems.Count();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.MediaItems.Remove(item);
            }
        }

        public MediaItem Get(Expression<Func<MediaItem, bool>> expression)
        {
            return _context.MediaItems.FirstOrDefault(expression);
        }

        public IEnumerable<MediaItem> GetAll()
        {
            return _context.MediaItems.Select(x => x);
        }

        public MediaItem GetById(int id)
        {
            return _context.MediaItems.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<MediaItem> GetMany(Expression<Func<MediaItem, bool>> expression)
        {
            return _context.MediaItems.Where(expression);
        }

        public void Insert(MediaItem obj)
        {
            _context.MediaItems.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(MediaItem obj)
        {
            _context.MediaItems.AddOrUpdate();
        }
    }
}
