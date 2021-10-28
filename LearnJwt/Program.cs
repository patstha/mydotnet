using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LearnJwt
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World");
            string clientSecret = "appleballcatdogeggfishgunhenicejugkitelionmonkeynestorangequeenroseshipteaumbrellavanwaterxylophoneyachtzebra";
            Console.WriteLine($"Client Secret: {clientSecret}");
            string unsignedToken = Newtonsoft.Json.JsonConvert.SerializeObject(new { email = "kushal@gmx.com" });
            Console.WriteLine($"Unsigned token: {unsignedToken}");
            string token = GenerateSignature(unsignedToken, clientSecret);
            Console.WriteLine($"Signed token: {token}");
        }

        /// <summary>
        /// Generates an HMACSHA256 signature for a given string and key.
        /// </summary>
        /// <param name="unsignedToken">The token to be signed.</param>
        /// <param name="clientSecret">The key used to generate the signature.</param>
        /// <returns>The generated signature.</returns>
        public static string GenerateSignature(string unsignedToken, string clientSecret)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clientSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);
            var payload = new JwtPayload
            {
                { "email", "kushal@gmx.com"},
                { "iat", DateTimeOffset.Now.ToUnixTimeSeconds() }
            };
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);
            // var token = handler.ReadJwtToken(tokenString);
            return tokenString;
        }
    }
}
