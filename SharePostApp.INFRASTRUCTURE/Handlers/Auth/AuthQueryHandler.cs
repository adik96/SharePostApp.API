using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SharePostApp.Core.Exceptions;
using SharePostApp.DB.Entities.Concrete;
using SharePostApp.DB.Repositories.Abstract;
using SharePostApp.INFRASTRUCTURE.DTOs.Auth;
using SharePostApp.INFRASTRUCTURE.Queries.User;
using SharePostApp.INFRASTRUCTURE.Services.Abstract;
using SharePostApp.INFRASTRUCTURE.Services.Concrete;

namespace SharePostApp.INFRASTRUCTURE.Handlers.Auth
{
    public class AuthQueryHandler : IRequestHandler<AuthQuery, AuthResponseDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jwtService;
        private readonly IPasswordService _passwordService;

        //private User user;

        public AuthQueryHandler(
            IUserRepository userRepository,
            IJWTService jwtService,
            IPasswordService passService
        )
        {
            this._userRepository = userRepository;
            this._jwtService = jwtService;
            this._passwordService = passService;
        }

        public async Task<AuthResponseDTO> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            var user = await CheckIfUserExsist(request);
            VerifyPassword(request, user);
            return new AuthResponseDTO(GenerateToken(user.Id));
        }

        private async Task<User> CheckIfUserExsist(AuthQuery request)
        {
            var user = await _userRepository.GetByEmail(request.Email);
            if (!user.IsActive)
                throw new MainException(ErrorCode.NotFound);

            return user;
        }

        private void VerifyPassword(AuthQuery request, User user)
        {
            _passwordService.VerifyPassword(request.Password, user.PasswordHash);
        }
        private string GenerateToken(long userId)
        {
            var token = _jwtService.CreateToken(userId);
            return token;
        }
    }
}
