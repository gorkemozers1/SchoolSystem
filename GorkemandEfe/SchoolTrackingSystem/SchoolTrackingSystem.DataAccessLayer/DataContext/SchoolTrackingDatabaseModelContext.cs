using Microsoft.EntityFrameworkCore;
using SchoolTrackingSystem.EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTrackingSystem.DataAccessLayer.DataContext
{
	public class SchoolTrackingDatabaseModelContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=104.247.167.130\MSSQLSERVER2019; Database=sarnovic_SchoolTrackingDatabase;User ID=sarnovic_SchoolTrackingDatabase; Password=Qv0k#w101;TrustServerCertificate=True;");
		}


		public virtual DbSet<Students> Students { get; set; }
	}
}
