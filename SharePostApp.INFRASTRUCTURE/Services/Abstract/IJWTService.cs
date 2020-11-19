namespace SharePostApp.INFRASTRUCTURE.Services.Abstract
{
    public interface IJWTService : IService
    {
        string CreateToken(long userId);
    }
}
