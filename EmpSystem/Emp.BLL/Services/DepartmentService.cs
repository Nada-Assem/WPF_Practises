using Emp.BLL.Interfaces;
using Emp.DLL.Context;
using Emp.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.BLL.Services
{
    public class DepartmentService : IGenericService<Deparment>
    {
        private readonly EmpSystemDbContext _context;

        public DepartmentService(EmpSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Deparment>> GetAllAsync()
        {
            return await _context.Deparments.ToListAsync();
        }

        public async Task<Deparment> GetByIdAsync(int id)
        {
            return await _context.Deparments.FindAsync(id);
        }

        public async Task AddAsync(Deparment department)
        {
            _context.Deparments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Deparment department)
        {
            _context.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var department = await _context.Deparments.FindAsync(id);
            if (department != null)
            {
                _context.Deparments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}
