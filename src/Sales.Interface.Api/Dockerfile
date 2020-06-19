#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Sales.Interface.Api/Sales.Interface.Api.csproj", "Sales.Interface.Api/"]
COPY ["Framework.Config/Framework.Config.csproj", "Framework.Config/"]
COPY ["Framework.Core/Framework.Core.csproj", "Framework.Core/"]
COPY ["Framework.Application/Framework.Application.csproj", "Framework.Application/"]
COPY ["Framework.NH/Framework.NH.csproj", "Framework.NH/"]
COPY ["Framework.Domain/Framework.Domain.csproj", "Framework.Domain/"]
COPY ["Sales.Interface.Facade.Contracts/Sales.Interface.Facade.Contracts.csproj", "Sales.Interface.Facade.Contracts/"]
COPY ["Sales.Application/Sales.Application.csproj", "Sales.Application/"]
COPY ["Sales.Domain/Sales.Domain.csproj", "Sales.Domain/"]
COPY ["Sales.Domain.Contracts/Sales.Domain.Contracts.csproj", "Sales.Domain.Contracts/"]
COPY ["Sales.Config/Sales.Config.csproj", "Sales.Config/"]
COPY ["Sales.Interface.Facade/Sales.Interface.Facade.csproj", "Sales.Interface.Facade/"]
COPY ["Sales.Interface.RabbitMq/Sales.Interface.RabbitMq.csproj", "Sales.Interface.RabbitMq/"]
COPY ["Warehouse.Domain.Contracts/Warehouse.Domain.Contracts.csproj", "Warehouse.Domain.Contracts/"]
COPY ["Sales.Persistence.NH/Sales.Persistence.NH.csproj", "Sales.Persistence.NH/"]
RUN dotnet restore "Sales.Interface.Api/Sales.Interface.Api.csproj"
COPY . .
WORKDIR "/src/Sales.Interface.Api"
RUN dotnet build "Sales.Interface.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sales.Interface.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sales.Interface.Api.dll"]
