﻿namespace RIIMS.Application.DTOs.UserDTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        //[MaxLength(50)]
        public string emri { get; set; } = "";

        public string mbiemri { get; set; } = "";

        public string? adresa { get; set; } = "";

        public string? gjinia { get; set; } = "";

        public DateTime? dataELindjes { get; set; }

        public string? numriTelefonit { get; set; }

        public string NiveliAkademik { get; set; }
        public Guid NiveliAkademikId { get; set; }

       // public IFormFile Image { get; set; }

        public Guid? ImageId { get; set; }
    }
}
