using System.Security.Claims;
using AutoMapper;
using Imdb.Domain.AuthAggregate.Dtos;
using Imdb.Domain.AuthAggregate.Entities;
using Imdb.Domain.AuthAggregate.Repositories;
using Imdb.Domain.AuthAggregate.Services;
using Imdb.Domain.Shared.Exceptions;
using Imdb.Domain.Shared.Filters;
using Imdb.Domain.Shared.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Imdb.Application.AuthServices
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(IMapper mapper, 
            IUserRepository userRepository, 
            IUnityOfWork unityOfWork, 
            IAuthService authService, 
            IHttpContextAccessor httpContext)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unityOfWork = unityOfWork;
            _authService = authService;
            _httpContext = httpContext;
        }

        public void RegisterAdmin(AdminForRegisterDto adminForRegisterDto)
        {
            var admin = _mapper.Map<User>(adminForRegisterDto);

            admin.PasswordHash = _authService.GeneratePasswordHash(adminForRegisterDto.Password);

            _userRepository.Create(admin);

            _unityOfWork.Commit();
        }

        public void RegisterUser(UserForRegisterDto userForRegisterDto)
        {
            var admin = _mapper.Map<User>(userForRegisterDto);

            admin.PasswordHash = _authService.GeneratePasswordHash(userForRegisterDto.Password);

            _userRepository.Create(admin);

            _unityOfWork.Commit();
        }

        public void UpdateUser(UserForUpdateDto userForUpdateDto)
        {
            var userId = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (userId != userForUpdateDto.Id) throw new CoreException("Voce so pode alterar o seu proprio Usuario.");

            var user = _userRepository.GetById(userId);

            user.Name = userForUpdateDto.Name;

            _userRepository.Update(user);

            _unityOfWork.Commit();
        }

        public void InactivateUserAsAdmin(int idUser)
        {
            var idToken = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userInacvating = _userRepository.GetById(idToken);

            if (!userInacvating.Admin) throw new CoreException("Voce nao tem permicao para inativar usuarios.");

            var userToInactivate = new User {Id = idUser, Active = false};

            _userRepository.Inactivate(userToInactivate);

            _unityOfWork.Commit();
        }

        public void InactivateUser()
        {
            var idToken = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userToInactivate = new User { Id = idToken, Active = false };

            _userRepository.Inactivate(userToInactivate);

            _unityOfWork.Commit();
        }

        public GenericFilter<UsersForList> GetUsers(GenericFilter<UsersForList> filter)
        {
            var result = _userRepository.GetUsers(filter);

            return result;
        }
    }
}
