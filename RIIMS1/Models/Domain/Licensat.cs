﻿namespace riims1.Models.Domain
{
    public class Licensat
    {
        public Guid Id { get; set; }

        public string Emri { get; set; }

        public DateTime DataLeshimit { get; set; }

        public DateTime? DataSkadimit { get; set; }

        public string? CredentialId { get; set; }

        public string? CredentialUrl { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public Guid InstitucioniId { get; set; }
        public Institucioni Institucioni { get; set; }
    }
}
