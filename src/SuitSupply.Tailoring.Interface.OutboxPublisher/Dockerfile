#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/SuitSupply.Tailoring.Interface.OutboxPublisher/SuitSupply.Tailoring.Interface.OutboxPublisher.csproj", "src/SuitSupply.Tailoring.Interface.OutboxPublisher/"]
RUN dotnet restore "src/SuitSupply.Tailoring.Interface.OutboxPublisher/SuitSupply.Tailoring.Interface.OutboxPublisher.csproj"
COPY . .
WORKDIR "/src/src/SuitSupply.Tailoring.Interface.OutboxPublisher"
RUN dotnet build "SuitSupply.Tailoring.Interface.OutboxPublisher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SuitSupply.Tailoring.Interface.OutboxPublisher.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SuitSupply.Tailoring.Interface.OutboxPublisher.dll"]