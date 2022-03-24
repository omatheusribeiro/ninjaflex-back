using AutoMapper;
using NinjaFlex.Application.Interfaces;
using NinjaFlex.Application.ViewModels;
using NinjaFlex.Domain.Entitites;
using NinjaFlex.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NinjaFlex.Application.Services
{
    public class TypeUserService : ITypeUserService
    {
        private ITypeUserRepository _typeUserRepository;
        private readonly IMapper _mapper;

        public TypeUserService(IMapper mapper, ITypeUserRepository typeUserRepository)
        {
            _typeUserRepository = typeUserRepository;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel> GetTypeUsers(TypeUserViewModel typeUser)
        {
            try
            {
                var mapTypeUser = _mapper.Map<TypeUser>(typeUser);

                var result = await _typeUserRepository.GetTypeUsers(mapTypeUser);

                var retorno = _mapper.Map<IEnumerable<TypeUserViewModel>>(result);

                if (retorno == null)
                    return new ResponseViewModel { Message = "Não foi possível encontrar o tipo do usuário!", Response = retorno, Success = false };

                return new ResponseViewModel { Message = "Tipos de usuário consultados com sucesso!", Response = retorno, Success = true };
            }
            catch (Exception ex)
            {
                return new ResponseViewModel { Message = "Houve um erro ao consultar os tipos de usuário!", Success = false, ErrorException = ex.Message };
            }
        }

        public async Task<ResponseViewModel> GetTypeUserById(int id)
        {
            try
            {
                var result = await _typeUserRepository.GetTypeUserById(id);

                var retorno = _mapper.Map<TypeUserViewModel>(result);

                if (retorno == null)
                    return new ResponseViewModel { Message = "Não foi possível encontrar o tipo do usuário!", Response = retorno, Success = false };

                return new ResponseViewModel { Message = "Tipo de usuário consultado com sucesso!", Response = retorno, Success = true };
            }
            catch (Exception ex)
            {
                return new ResponseViewModel { Message = "Houve um erro ao consultar o tipo de usuário!", Success = false, ErrorException = ex.Message };
            }

        }

        public async Task<ResponseViewModel> PutTypeUser(TypeUserViewModel typeUser)
        {

            try
            {

                var mapTypeUser = _mapper.Map<TypeUser>(typeUser);

                var result = await _typeUserRepository.PutTypeUser(mapTypeUser);

                var retorno = _mapper.Map<TypeUserViewModel>(result);

                return new ResponseViewModel { Message = "Tipo de usuário alterado com sucesso!", Response = retorno, Success = true };
            }
            catch (Exception ex)
            {
                return new ResponseViewModel { Message = "Houve um erro ao alterar o tipo de usuário!", Success = false, ErrorException = ex.Message };
            }

        }

        public async Task<ResponseViewModel> PostTypeUser(TypeUserViewModel typeUser)
        {
            try
            {
                var mapTypeUser = _mapper.Map<TypeUser>(typeUser);

                var result = await _typeUserRepository.PostTypeUser(mapTypeUser);

                var retorno = _mapper.Map<TypeUserViewModel>(result);

                return new ResponseViewModel { Message = "Tipo de usuário cadastrado com sucesso!", Response = retorno, Success = true };
            }
            catch (Exception ex)
            {
                return new ResponseViewModel { Message = "Houve um erro ao cadastrar o tipo de usuário!", Success = false, ErrorException = ex.Message };
            }
        }
    }
}
