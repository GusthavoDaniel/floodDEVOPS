namespace FloodWatch.API.Configuration
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpirationHours { get; set; } = 24;
    }

    public class ApiSettings
    {
        public string Version { get; set; } = "v1";
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ContactInfo Contact { get; set; } = new();
    }

    public class ContactInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class CorsSettings
    {
        public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
        public string[] AllowedMethods { get; set; } = Array.Empty<string>();
        public string[] AllowedHeaders { get; set; } = Array.Empty<string>();
    }
}

