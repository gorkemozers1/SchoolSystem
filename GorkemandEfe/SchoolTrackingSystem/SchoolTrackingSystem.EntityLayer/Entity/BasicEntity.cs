using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTrackingSystem.EntityLayer.Entity
{
	public class BasicEntity
	{
        public BasicEntity()
        {
            IsActive = false;
        }

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Birincil Anahtar/ 1den başlayıp her kayıt eklendiğinde 1 er aratarak devam edecek
        public int ID { get; set; }
        public bool IsActive { get; set; }
    }
}
