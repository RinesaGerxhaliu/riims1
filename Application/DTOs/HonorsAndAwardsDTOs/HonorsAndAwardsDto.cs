namespace RIIMS.Application.DTOs.HonorsAndAwardsDTOs
{
    public class HonorsAndAwardsDTO
    {
        public Guid Id { get; set; }

        public string titulli { get; set; }

        public string issuer { get; set; }

        public DateTime dataEleshimit { get; set; }

        public string pershkrimi { get; set; }

        public string EmriInstitucionit { get; set; }

        public string UserId { get; set; }

        public Guid InstitucioniId { get; set; }

    }
}
