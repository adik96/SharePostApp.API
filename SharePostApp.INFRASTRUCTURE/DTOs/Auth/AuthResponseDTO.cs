namespace SharePostApp.INFRASTRUCTURE.DTOs.Auth
{
    public class AuthResponseDTO
    {
        public string Token { get; set; }

        public AuthResponseDTO()
        {

        }

        public AuthResponseDTO(string token)
        {
            Token = token;
        }
    }
}
