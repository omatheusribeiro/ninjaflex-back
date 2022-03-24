using AutoMapper;
using NinjaFlex.Application.Helpers.Authentication;
using NinjaFlex.Application.Interfaces;
using NinjaFlex.Application.ViewModels;
using NinjaFlex.Domain.Entitites;
using NinjaFlex.Domain.Interfaces;

namespace NinjaFlex.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel> GetUsers(UserViewModel user)
        {
            try
            {
                var mapUser = _mapper.Map<User>(user);

                var users = await _userRepository.GetUsers(mapUser);

                var retorno = _mapper.Map<IEnumerable<UserViewModel>>(users);

                if (retorno == null)
                    return new ResponseViewModel { Message = "Não foi possível encontrar o usuário!", Response = retorno, Success = false };

                return new ResponseViewModel { Message = "Usuários consultados com sucesso!", Response = retorno, Success = true};

            }
            catch (Exception ex)
            {
                return new ResponseViewModel { Message = "Houve um erro ao consultar os usuários!", Success = false, ErrorException = ex.Message };
            }

        }

        public async Task<ResponseViewModel> GetUserById(int id)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);

                var retorno = _mapper.Map<UserViewModel>(user);

                if (retorno == null)
                    return new ResponseViewModel { Message = "Não foi possível encontrar o usuário!", Response = retorno, Success = false };

                return new ResponseViewModel { Message = "Usuário consultado com sucesso!", Response = retorno, Success = true };

            }
            catch (Exception ex)
            {
                return new ResponseViewModel { Message = "Houve um erro ao consultar o usuário!", Success = false, ErrorException = ex.Message };
            }

        }

        public async Task<ResponseViewModel> PutUser(UserViewModel user)
        {
            try
            {

                var mapUser = _mapper.Map<User>(user);

                var result = await _userRepository.PutUser(mapUser);

                var retorno = _mapper.Map<UserViewModel>(result);

                return new ResponseViewModel { Message = "Usuário alterado com sucesso!", Response = retorno, Success = true };

            }
            catch (Exception ex)
            {
                return new ResponseViewModel { Message = "Houve um erro ao alterar o usuário!", Success = false, ErrorException = ex.Message };
            }

        }

        public async Task<ResponseViewModel> PostUser(UserViewModel user)
        {
            try
            {

                var mapUser = _mapper.Map<User>(user);

                var result = await _userRepository.PostUser(mapUser);

                var retorno = _mapper.Map<UserViewModel>(result);

                return new ResponseViewModel { Message = "Usuário cadastrado com sucesso!", Response = retorno, Success = true };

            }
            catch (Exception ex)
            {
                return new ResponseViewModel { Message = "Houve um erro ao cadastrar o usuário!", Success = false, ErrorException = ex.Message };
            }

        }

        public async Task<ResponseViewModel> AuthenticateUser(string barCode)
        {
            try
            {
                dynamic result;

                if (!string.IsNullOrEmpty(barCode))
                {
                    result = await _userRepository.AuthenticateUser(barCode);
                }
                else
                {
                    return new ResponseViewModel { Message = "Por favor, informe o código de barras!", Success = false };
                }


                if (result != null)
                {
                    var token = TokenAuthenticate.GenerateToken(result);

                    return new ResponseViewModel { Message = "Requisição realizada com sucesso", Response = token, Success = true };
                }
                else
                {
                    return new ResponseViewModel { Message = "Houve um erro ao autenticar o usuário, consulte o administrador!", Success = false };
                }

            }
            catch (Exception ex)
            {
                return new ResponseViewModel { Message = "Houve um erro ao autenticar o usuário!", Success = false, ErrorException = ex.Message };
            }

        }
    }
}
