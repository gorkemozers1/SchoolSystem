using SchoolTrackingSystem.EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTrackingSystem.EntityLayer.Model
{
	[Table("Students",Schema ="dbo")]
	public class Students:BasicEntity,IEntity
	{
        public string? NameSurname { get; set; }
		public string? Classroom { get; set; }
		public int SchoolNumber { get; set; }
		public ulong PhoneNumber { get; set; }
		public string? Email { get; set; }
		public ulong MotherNumber { get; set; }
		public ulong FatherNumber { get; set; }
    }
}
