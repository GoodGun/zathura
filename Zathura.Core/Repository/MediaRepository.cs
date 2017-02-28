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
    public class MediaRepository : IMediaRepository
    {
        private readonly ZathuraContext _context = new ZathuraContext();
        public int Count()
        {
            return _context.Medias.Count();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Medias.Remove(item);
            }
        }

        public Media Get(Expression<Func<Media, bool>> expression)
        {
            return _context.Medias.FirstOrDefault(expression);
        }

        public IEnumerable<Media> GetAll()
        {
            return _context.Medias.Select(x => x);
        }

        public Media GetById(int id)
        {
            return _context.Medias.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Media> GetMany(Expression<Func<Media, bool>> expression)
        {
            return _context.Medias.Where(expression);
        }

        public void Insert(Media obj)
        {
            _context.Medias.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Media obj)
        {
            _context.Medias.AddOrUpdate();
        }
    }
}
