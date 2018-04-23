namespace Api.Infrastructure.Configuration
{
    public class JwtConfig
    {
        public string Key {get; set;}
        public string Issuer {get; set;}
        public int ExpiryMinutes {get; set;}
    }
}