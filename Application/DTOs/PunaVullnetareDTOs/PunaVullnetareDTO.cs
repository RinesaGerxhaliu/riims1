namespace RIIMS.Application.DTOs.PunaVullnetareDTOs
{
    public class PunaVullnetareDTO
    {
        public Guid Id { get; set; }

        public string Roli { get; set; }

        public DateTime DataFillimit { get; set; }

        public DateTime? DataMbarimit { get; set; }

        public string? Pershkrimi { get; set; }

        public string EmriInstitucionit { get; set; }

        public string UserId { get; set; }

        public Guid InstitucioniId { get; set; }
    }
}
