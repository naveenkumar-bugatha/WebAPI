using Mapster;
using SchoolManagement.Application.Authentication.Commands.Register;
using SchoolManagement.Application.Authentication.Common;
using SchoolManagement.Application.Authentication.Queries.Login;
using SchoolManagement.Contracts.Authentication;

namespace SchoolManagement.Api.Common.Mappings
{
    public class SchoolManagementMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LoginQuery>().MapToConstructor(true);
            config.NewConfig<RegisterRequest, RegisterCommand>().MapToConstructor(true);
            config.NewConfig<AuthenticationResult, AuthenticationResponse>().MapToConstructor(true);
        }
    }
}
