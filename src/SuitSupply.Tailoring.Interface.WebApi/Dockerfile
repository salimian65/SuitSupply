#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/SuitSupply.Tailoring.Interface.WebApi/SuitSupply.Tailoring.Interface.WebApi.csproj", "src/SuitSupply.Tailoring.Interface.WebApi/"]
RUN dotnet restore "src/SuitSupply.Tailoring.Interface.WebApi/SuitSupply.Tailoring.Interface.WebApi.csproj"
COPY . .
WORKDIR "/src/src/SuitSupply.Tailoring.Interface.WebApi"
RUN dotnet build "SuitSupply.Tailoring.Interface.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SuitSupply.Tailoring.Interface.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SuitSupply.Tailoring.Interface.WebApi.dll"]