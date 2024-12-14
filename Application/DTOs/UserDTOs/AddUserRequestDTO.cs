﻿namespace RIIMS1.Application.DTOs.UserDTOs
{
    public class AddUserRequestDTO
    {
        public string emri { get; set; } = "";

        public string mbiemri { get; set; } = "";

        public string? adresa { get; set; } = "";

        public string? gjinia { get; set; } = "";

        public DateTime? dataELindjes { get; set; }

        public string? numriTelefonit { get; set; }

        public string NiveliAkademik { get; set; }

        public string foto { get; set; }
    }
}
