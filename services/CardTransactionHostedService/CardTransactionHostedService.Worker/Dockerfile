FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/CardTransactionHostedService/CardTransactionHostedService.Worker/CardTransactionHostedService.Worker.csproj", "services/CardTransactionHostedService/CardTransactionHostedService.Worker/"]
RUN dotnet restore "services/CardTransactionHostedService/CardTransactionHostedService.Worker/CardTransactionHostedService.Worker.csproj"
COPY . .
WORKDIR "/src/services/CardTransactionHostedService/CardTransactionHostedService.Worker"
RUN dotnet build "CardTransactionHostedService.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CardTransactionHostedService.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CardTransactionHostedService.Worker.dll"]
