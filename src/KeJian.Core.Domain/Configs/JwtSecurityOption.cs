namespace KeJian.Core.Domain.Configs
{
    public class JwtSecurityOption
    {
        //  * SigningKey length >= 16 *
        public string SigningKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}