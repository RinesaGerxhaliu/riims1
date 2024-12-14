namespace RIIMS1.Application.DTOs.PunaVullnetareDTOs
{
    public class AddPunaVullnetareRequestDTO
    {
        public string Roli { get; set; }

        public DateTime DataFillimit { get; set; }

        public DateTime? DataMbarimit { get; set; }

        public string? Pershkrimi { get; set; }

        public string EmriInstitucionit { get; set; }
    }
}
