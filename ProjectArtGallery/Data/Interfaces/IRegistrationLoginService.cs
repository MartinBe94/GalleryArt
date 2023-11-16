namespace Data.Interfaces;

public interface IRegistrationLoginService
{
    User GetUserByEmailOrUsername(string emailOrUsername);
    string GenerateJwtToken(User user);

}
