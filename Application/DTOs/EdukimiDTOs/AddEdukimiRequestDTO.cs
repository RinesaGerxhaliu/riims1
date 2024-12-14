﻿namespace RIIMS1.Application.DTOs.EdukimiDTOs
{
    public class AddEdukimiRequestDTO
    {
        public string FushaStudimit { get; set; }

        public string Lokacioni { get; set; }

        public DateTime DataFillimit { get; set; }

        public DateTime? DataMbarimit { get; set; }

        public string? Pershkrimi { get; set; }

        public string Institucioni { get; set; }

        public string NiveliAkademik { get; set; }
       
    }
}
