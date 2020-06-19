#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Warehouse.Interface.Api/Warehouse.Interface.Api.csproj", "Warehouse.Interface.Api/"]
COPY ["Framework.Config/Framework.Config.csproj", "Framework.Config/"]
COPY ["Framework.Core/Framework.Core.csproj", "Framework.Core/"]
COPY ["Framework.Application/Framework.Application.csproj", "Framework.Application/"]
COPY ["Framework.NH/Framework.NH.csproj", "Framework.NH/"]
COPY ["Framework.Domain/Framework.Domain.csproj", "Framework.Domain/"]
COPY ["Warehouse.Config/Warehouse.Config.csproj", "Warehouse.Config/"]
COPY ["Warehouse.Application/Warehouse.Application.csproj", "Warehouse.Application/"]
COPY ["Sales.Domain.Contracts/Sales.Domain.Contracts.csproj", "Sales.Domain.Contracts/"]
COPY ["Warehouse.Domain/Warehouse.Domain.csproj", "Warehouse.Domain/"]
COPY ["Warehouse.Domain.Contracts/Warehouse.Domain.Contracts.csproj", "Warehouse.Domain.Contracts/"]
COPY ["Warehouse.Interface.Facade.Contracts/Warehouse.Interface.Facade.Contracts.csproj", "Warehouse.Interface.Facade.Contracts/"]
COPY ["Warehouse.Persistence.NH/Warehouse.Persistence.NH.csproj", "Warehouse.Persistence.NH/"]
COPY ["Warehouse.Interface.RabbitMq/Warehouse.Interface.RabbitMq.csproj", "Warehouse.Interface.RabbitMq/"]
COPY ["Warehouse.Interface.Facade/Warehouse.Interface.Facade.csproj", "Warehouse.Interface.Facade/"]
RUN dotnet restore "Warehouse.Interface.Api/Warehouse.Interface.Api.csproj"
COPY . .
WORKDIR "/src/Warehouse.Interface.Api"
RUN dotnet build "Warehouse.Interface.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Warehouse.Interface.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Warehouse.Interface.Api.dll"]
