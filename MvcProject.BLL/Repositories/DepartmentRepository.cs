using MvcProject.BLL.IEnterfacies;
using MvcProject.DAL.Data.Contexts;
using MvcProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }



        public int Add(Department department)
        {
            _context.Add(department);
            return _context.SaveChanges();
        }

        public int Delete(Department department)
        {
            _context.Remove(department);
            return _context.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.Find(id);
        }

        public int Update(Department department)
        {
            _context.Update(department);
            return _context.SaveChanges();
        }
    }
}
