using MediatR;
using SharePostApp.INFRASTRUCTURE.DTOs.Auth;
using System.Collections.Generic;

namespace SharePostApp.INFRASTRUCTURE.Queries.User
{
    public class AuthQuery : IRequest<AuthResponseDTO>
    {
        public AuthQuery() { }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
