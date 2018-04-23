using Api.ViewModels;

namespace Api.Services
{
    public interface IJwtHandler
    {
         JwtViewModel CreateToken(string userId, string role);
    }
}