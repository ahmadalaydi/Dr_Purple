FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Dr_Purple.Api/Dr_Purple.Api.csproj", "Dr_Purple.Api/"]
COPY ["Dr_Purple.Application/Dr_Purple.Application.csproj", "Dr_Purple.Application/"]
COPY ["Dr_Purple.Domain/Dr_Purple.Core.csproj", "Dr_Purple.Domain/"]
RUN dotnet restore "Dr_Purple.Api/Dr_Purple.Api.csproj"
COPY . .
WORKDIR "/src/Dr_Purple.Api"
RUN dotnet build "Dr_Purple.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dr_Purple.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dr_Purple.Api.dll"]