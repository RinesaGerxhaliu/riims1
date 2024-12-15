﻿namespace RIIMS.Application.DTOs.EdukimiDTOs
{
    public class EksperiencaDTO
    {
        public Guid Id { get; set; }

        public string Titulli { get; set; }

        public string LlojiPunesimit { get; set; }

        public string Lokacioni { get; set; }

        public string LlojiLokacionit { get; set; }

        public DateTime DataFillimit { get; set; }

        public DateTime? DataMbarimit { get; set; }

        public string EmriInstitucionit { get; set; }

        public string? Pershkrimi { get; set; }

        public string UserId { get; set; }
        public Guid InstitucioniId { get; set; }

    }
}
