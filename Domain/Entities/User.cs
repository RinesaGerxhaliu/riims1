using Microsoft.AspNetCore.Identity;

namespace RIIMS.Domain.Entities
{
    public class User : IdentityUser
    {
        public string emri { get; set; } 

        public string mbiemri { get; set; } 

        public string? Adresa { get; set; } 

        public string? gjinia { get; set; } 

        public DateTime? dataELindjes { get; set; } 

        public string? numriTelefonit { get; set; }

        public Guid? ImageId { get; set; }

        // Navigation Property
        public Image Image { get; set; }

        //Foreign Key
        public Guid? NiveliAkademikId { get; set; }

        //Navigation Property
       public NiveliAkademik NiveliAkademik { get; set; }
    }
}