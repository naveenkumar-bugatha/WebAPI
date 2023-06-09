﻿namespace SchoolManagement.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public string Secret { get; init; } = null!;
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
        public double Expiry { get; init; }
    }
}
