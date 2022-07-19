#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SuitSupply.Tailoring.OrderManagement.Listener/SuitSupply.Tailoring.OrderManagement.Listener.csproj", "src/SuitSupply.Tailoring.OrderManagement.Listener/"]
COPY ["src/SuitSupply.Framework.Core/SuitSupply.Framework.Core.csproj", "src/SuitSupply.Framework.Core/"]
COPY ["src/SuitSupply.Framework.Domain/SuitSupply.Framework.Domain.csproj", "src/SuitSupply.Framework.Domain/"]
COPY ["src/SuitSupply.Tailoring.Application.Contracts/SuitSupply.Tailoring.Application.Contracts.csproj", "src/SuitSupply.Tailoring.Application.Contracts/"]
RUN dotnet restore "src/SuitSupply.Tailoring.OrderManagement.Listener/SuitSupply.Tailoring.OrderManagement.Listener.csproj"
COPY . .
WORKDIR "/src/src/SuitSupply.Tailoring.OrderManagement.Listener"
RUN dotnet build "SuitSupply.Tailoring.OrderManagement.Listener.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SuitSupply.Tailoring.OrderManagement.Listener.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SuitSupply.Tailoring.OrderManagement.Listener.dll"]