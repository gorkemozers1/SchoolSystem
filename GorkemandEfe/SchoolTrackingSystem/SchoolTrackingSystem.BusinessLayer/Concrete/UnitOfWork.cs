using Microsoft.EntityFrameworkCore;
using SchoolTrackingSystem.EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTrackingSystem.BusinessLayer.Concrete
{
	public class UnitOfWork
	{
		readonly DbContext _context;
		public EntityRepositoryBase<Students> studentsEntityRepositoryBase { get; set; }
		public UnitOfWork(DbContext context)
		{
			_context = context;
			studentsEntityRepositoryBase = new EntityRepositoryBase<Students>(context);
		}
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
