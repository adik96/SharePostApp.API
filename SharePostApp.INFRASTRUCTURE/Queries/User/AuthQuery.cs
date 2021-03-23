using MediatR;
using SharePostApp.INFRASTRUCTURE.DTOs.Auth;
using System.ComponentModel.DataAnnotations;

namespace SharePostApp.INFRASTRUCTURE.Queries.User
{
    public class AuthQuery : IRequest<AuthResponseDTO>
    {
        public AuthQuery() { }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        public string Password { get; set; }
    }
}
