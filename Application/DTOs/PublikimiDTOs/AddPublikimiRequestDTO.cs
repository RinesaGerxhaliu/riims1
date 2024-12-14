namespace RIIMS1.Application.DTOs.PublikimiDTOs
{
    public class AddPublikimiRequestDTO
    {
        public string Titulli { get; set; }

        public string LlojiPublikimit { get; set; }

        public string? LinkuPublikimit { get; set; }

        public bool? AutoriKryesor { get; set; }

        public DateTime DataPublikimi { get; set; }

        public string EmriDepartamentit { get; set; }

    }
}
