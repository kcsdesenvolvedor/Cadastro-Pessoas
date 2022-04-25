#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cadastro_De_Pessoas.API/Cadastro_De_Pessoas.API.csproj", "Cadastro_De_Pessoas.API/"]
COPY ["Cadastro_De_Pessoas.APPLICATION/Cadastro_De_Pessoas.APPLICATION.csproj", "Cadastro_De_Pessoas.APPLICATION/"]
COPY ["Cadastro_De_Pessoas.DOMAIN/Cadastro_De_Pessoas.DOMAIN.csproj", "Cadastro_De_Pessoas.DOMAIN/"]
COPY ["Cadastro_De_Pessoas.INFRA/Cadastro_De_Pessoas.INFRA.csproj", "Cadastro_De_Pessoas.INFRA/"]
RUN dotnet restore "Cadastro_De_Pessoas.API/Cadastro_De_Pessoas.API.csproj"
COPY . .
WORKDIR "/src/Cadastro_De_Pessoas.API"
RUN dotnet build "Cadastro_De_Pessoas.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cadastro_De_Pessoas.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cadastro_De_Pessoas.API.dll"]