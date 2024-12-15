namespace RIIMS.Domain.Entities
{
    public class Aftesite
    {
        public Guid Id { get; set; }
        
        public string Emri { get; set; }

        //Foreign Key
        public int UserId { get; set; }

        //Navigation Property
        public User User { get; set; }

        //Foreign Key
        public Guid InstitucioniId { get; set; }

        //Navigation Property
        public Institucioni Institucioni { get; set; }
    }
}
