namespace riims1.Models.Domain
{
    public class NiveliGjuhesor
    {
        public Guid Id { get; set; }

        public string Niveli { get; set; }

        public ICollection<UserGjuhet> UserGjuhet { get; set; } = new HashSet<UserGjuhet>();
    }
}
