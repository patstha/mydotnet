using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LearnJwt
{
    [TestClass]
    public class LearnJwt
    {
        /// <summary>
        /// Generates an HMACSHA256 signature for a given payload and key.
        /// </summary>
        /// <param name="unsignedToken">The token to be signed.</param>
        /// <param name="clientSecret">The key used to generate the signature.</param>
        /// <returns>The generated signature.</returns>
        public string GenerateSignature(JwtPayload payload, string clientSecret)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clientSecret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtHeader header = new JwtHeader(credentials);
            JwtSecurityToken secToken = new JwtSecurityToken(header, payload);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string tokenString = handler.WriteToken(secToken);
            return tokenString;
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            string expectedEmail = "kushal@gmx.com";
            long expectedTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            string clientSecret = "appleballcatdogeggfishgunhenicejugkitelionmonkeynestorangequeenroseshipteaumbrellavanwaterxylophoneyachtzebra";
            var payload = new JwtPayload
            {
                { "email", expectedEmail },
                { "iat", expectedTimestamp }
            };

            // Act 
            string token = GenerateSignature(payload, clientSecret);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(token);

            // Assert
            jwtSecurityToken.Payload.Count.Should().Be(2);
            jwtSecurityToken.Payload.ContainsKey("email");
            jwtSecurityToken.Payload.ContainsKey("iat");
            jwtSecurityToken.Payload.ContainsValue(expectedEmail);
            jwtSecurityToken.Payload.ContainsValue(expectedTimestamp);
        }
    }
}
