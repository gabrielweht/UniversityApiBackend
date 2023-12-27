namespace UniversityApiBackend.Models
{
    public class JwtSettings
    {
        public bool ValidateIssuerSingingKey { get; set; }
        public string IssuerSingingKey { get; set; } = string.Empty;
        public bool ValidateIssuer { get; set; } = true;
        public string? ValidIssuer { get; set; }
        public bool ValidateAudience { get; set; } = true;
        public string? ValidAudience { get; set;}
        public bool RequiereExpirationTime { get; set; };
        public bool ValidateLifeTime { get; set; } = true;

    }
}
