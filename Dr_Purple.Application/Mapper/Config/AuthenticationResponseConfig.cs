using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.AuthenticationServices.Commands;
using Mapster;

namespace Dr_Purple.Application.Mapper.Config;
public class AuthenticationResponseConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResponse, RegisterCommand>()
            .Map(dest => dest, src => src);
    }
}