using NinjaFlex.Domain.Entitites.BaseEntitie;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaFlex.Domain.Entitites
{
    public class User : EntitieBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public bool Status { get; set; }

        public DateTime? DateLogin { get; set; }

        [ForeignKey("TypeUserId")]
        public int TypeUserId { get; set; }

        public virtual TypeUser TypeUser { get; set; }

        public string BarCode { get; set; }
    }
}
