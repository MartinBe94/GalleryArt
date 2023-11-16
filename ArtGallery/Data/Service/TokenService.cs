using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Data.Service;

public class TokenService
{
    public string GenerateToken(string userId, string userName)
    {
        // Set the secret key used to sign the token. This should be kept secure.
        var key = new SymmetricSecurityKey(Guid.NewGuid().ToByteArray());

        // Create signing credentials using the key and the algorithm (HmacSha256)
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Create a list of claims (information about the user)
        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, userId),
        new Claim(JwtRegisteredClaimNames.UniqueName, userName),
        // Add more claims as needed
    };

        // Create the token
        var token = new JwtSecurityToken(
            issuer: "your_issuer", // Replace with your issuer
            audience: "your_audience", // Replace with your audience
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15), // Set the expiration time
            signingCredentials: creds
        );

        // Return the token as a string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
