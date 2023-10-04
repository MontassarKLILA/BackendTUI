#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 63494
EXPOSE 63495


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CustomersAPI/TravelAgencyApis.csproj", "CustomersAPI/"]
COPY ["SharedLib/SharedLib.csproj", "SharedLib/"]
RUN dotnet restore "CustomersAPI/TravelAgencyApis.csproj"
COPY . .
WORKDIR "/src/CustomersAPI"
RUN dotnet build "TravelAgencyApis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelAgencyApis.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelAgencyApis.dll"]