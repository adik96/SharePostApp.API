using System;
using SharePostApp.Core.Exceptions;
using SharePostApp.INFRASTRUCTURE.Services.Abstract;
using BC = BCrypt.Net.BCrypt;

namespace SharePostApp.INFRASTRUCTURE.Services.Concrete
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            if(!String.IsNullOrEmpty(password))
                return BC.HashPassword(password);
            else
            {
                return null;
            }
        }

        public void VerifyPassword(string password, string passwordHash)
        {
            if (!BC.Verify(password, passwordHash))
            {
                throw new MainException(ErrorCode.NotFound, "User could not be found");
            }

        }
    }
}
