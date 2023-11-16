namespace Data.Service;

public class RegistrationLoginService
{
    private readonly ArtGalleryContext _context;
    public RegistrationLoginService(ArtGalleryContext context)
    {
        _context = context;
    }
    public User GetUserByEmailOrUsername(string emailOrUsername)
    {
        // Replace 'YourDbContext' with your actual DbContext class name
        {
            return _context.Users
          .FirstOrDefault(u => u.Email == emailOrUsername || u.Username == emailOrUsername);
        }
    }

    public string GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
        // Add more claims as needed (e.g., user roles or additional user data)
    };

        var token = new JwtSecurityToken(
            issuer: "your-issuer",
            audience: "your-audience",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1), // Token expiration time
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


}
