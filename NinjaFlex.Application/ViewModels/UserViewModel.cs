using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NinjaFlex.Application.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [DisplayName("LastName")]
        public string LastName { get; set; }

        [MaxLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [MaxLength(15)]
        [DisplayName("BarCode")]
        public string BarCode { get; set; }

        public int TypeUserId { get; set; }

        public bool Status { get; set; }
    }
}
