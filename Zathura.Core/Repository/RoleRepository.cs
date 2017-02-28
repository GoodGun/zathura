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
    public class RoleRepository : IRoleRepository
    {
        private readonly ZathuraContext _context = new ZathuraContext();
        public int Count()
        {
            return _context.Roles.Count();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Roles.Remove(item);
            }
        }

        public Role Get(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles.FirstOrDefault(expression);
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.Select(x => x);
        }

        public Role GetById(int id)
        {
            return _context.Roles.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Role> GetMany(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles.Where(expression);
        }

        public void Insert(Role obj)
        {
            _context.Roles.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Role obj)
        {
            _context.Roles.AddOrUpdate();
        }
    }
}
