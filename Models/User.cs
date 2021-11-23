using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyInvites.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "İsim Soyisim boş girilemez.")]
        [StringLength(40, ErrorMessage = "Başlık 40 haneden fazla olamaz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen hangi amaçla katılacağınızı seçiniz.")]
        public Role Role { get; set; }

        public virtual UserDetail UserDetail { get; set; }
        public int PartyId { get; set; }
        [ForeignKey("PartyId")]
        public virtual Party Party { get; set; }
    }
}
