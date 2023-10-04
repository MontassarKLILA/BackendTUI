#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 63498
EXPOSE 63499

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CustomerFileAPI/CustomerFileAPI.csproj", "CustomerFileAPI/"]
COPY ["SharedLib/SharedLib.csproj", "SharedLib/"]
RUN dotnet restore "CustomerFileAPI/CustomerFileAPI.csproj"
COPY . .
WORKDIR "/src/CustomerFileAPI"
RUN dotnet build "CustomerFileAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerFileAPI.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerFileAPI.dll"]