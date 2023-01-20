FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/CardManagement/CardManagement.Api/CardManagement.Api.csproj", "services/CardManagement/CardManagement.Api/"]
RUN dotnet restore "services/CardManagement/CardManagement.Api/CardManagement.Api.csproj"
COPY . .
WORKDIR "/src/services/CardManagement/CardManagement.Api"
RUN dotnet build "CardManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CardManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CardManagement.Api.dll"]
