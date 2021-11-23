using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartyInvites.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Kategori başlığı boş girilemez.")]
        [StringLength(30, ErrorMessage = "Başlık 30 haneden fazla olamaz")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Kategori açıklaması boş girilemez.")]
        [StringLength(150, ErrorMessage ="Açıklama 150 haneden fazla olamaz")]
        public string Description { get; set; }
    }
}
