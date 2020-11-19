namespace SharePostApp.INFRASTRUCTURE.Services.Abstract
{
    public interface IPasswordService : IService
    {
        string HashPassword(string password);
        void VerifyPassword(string password, string passwordHash);
    }
}
