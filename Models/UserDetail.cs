using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class UserDetail : BaseEntity
    {
        [Required(ErrorMessage = "E-mail adresi boş girilemez.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon boş girilemez.")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Yaş boş girilemez.")]
        [Range(18, 45, ErrorMessage = "Yaşınız 18-45 aralığında olmalıdır.")]
        public int Age { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]

        public virtual User User { get; set; }
    }
}
