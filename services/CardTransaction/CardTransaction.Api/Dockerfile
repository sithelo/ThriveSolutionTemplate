FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/CardTransaction/CardTransaction.Api/CardTransaction.Api.csproj", "services/CardTransaction/CardTransaction.Api/"]
RUN dotnet restore "services/CardTransaction/CardTransaction.Api/CardTransaction.Api.csproj"
COPY . .
WORKDIR "/src/services/CardTransaction/CardTransaction.Api"
RUN dotnet build "CardTransaction.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CardTransaction.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CardTransaction.Api.dll"]
