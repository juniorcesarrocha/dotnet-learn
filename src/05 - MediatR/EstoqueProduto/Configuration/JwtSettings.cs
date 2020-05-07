namespace EstoqueProduto.Configuration
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpiredTime { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}