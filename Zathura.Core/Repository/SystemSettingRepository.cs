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
    public class SystemSettingRepository : ISystemSettingRepository
    {
        private readonly ZathuraContext _context = new ZathuraContext();
        public int Count()
        {
            return _context.SystemSettings.Count();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.SystemSettings.Remove(item);
            }
        }

        public SystemSetting Get(Expression<Func<SystemSetting, bool>> expression)
        {
            return _context.SystemSettings.FirstOrDefault(expression);
        }

        public IEnumerable<SystemSetting> GetAll()
        {
            return _context.SystemSettings.Select(x => x);
        }

        public SystemSetting GetById(int id)
        {
            return _context.SystemSettings.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<SystemSetting> GetMany(Expression<Func<SystemSetting, bool>> expression)
        {
            return _context.SystemSettings.Where(expression);
        }

        public void Insert(SystemSetting obj)
        {
            _context.SystemSettings.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(SystemSetting obj)
        {
            _context.SystemSettings.AddOrUpdate();
        }
    }
}
