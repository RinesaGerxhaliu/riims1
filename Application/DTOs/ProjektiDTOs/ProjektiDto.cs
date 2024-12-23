namespace RIIMS.Application.DTOs.ProjektiDTOs
{
    public class ProjektiDto
    {
        public Guid Id { get; set; }

        public string emriProjektit { get; set; }

        public DateTime startDate { get; set; }

        public DateTime? endDate { get; set; }

        public string? collaborators { get; set; }

        public string description { get; set; }

        public string EmriInstitucionit { get; set; }

        public string UserId { get; set; }

        public Guid InstitucioniId { get; set; }
    }
}
