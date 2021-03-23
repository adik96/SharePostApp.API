using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SharePostApp.DB.Repositories.Abstract;
using SharePostApp.INFRASTRUCTURE.Commands.UserCommands;
using SharePostApp.INFRASTRUCTURE.Services.Abstract;
using dbEntities = SharePostApp.DB.Entities.Concrete;

namespace SharePostApp.INFRASTRUCTURE.Handlers.User
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, long>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        private dbEntities.User _registerUser = new dbEntities.User();
        public RegisterUserHandler(IUserRepository userRepository, IPasswordService passwordService, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._passwordService = passwordService;
            this._mapper = mapper;
        }

        public async Task<long> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            _mapper.Map(command, _registerUser);
            _registerUser.PasswordHash = _passwordService.HashPassword(command.Password);

            await _userRepository.AddAsync(_registerUser);

            return _registerUser.Id;
        }
    }
}
