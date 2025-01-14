namespace RIIMS.Domain.Entities
{
    public class Departamenti
    {
        public Guid Id { get; set; }

        public string Emri { get; set; }

        public Guid InstitucioniId { get; set; }

        public Institucioni Institucioni { get; set; }
    }
}
