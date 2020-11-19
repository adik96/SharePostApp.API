namespace SharePostApp.Core.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public int Expiry { get; set; }
    }
}
