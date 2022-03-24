using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NinjaFlex.Application.ViewModels
{
    public class TypeUserViewModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [DisplayName("Description")]
        public string Description { get; set; }

        public bool Status { get; set; }
    }
}
