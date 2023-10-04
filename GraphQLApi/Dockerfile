FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 63496
EXPOSE 63497


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GraphQLApi/GraphQLApi.csproj", "GraphQLApi/"]
COPY ["SharedLib/SharedLib.csproj", "SharedLib/"]
RUN dotnet restore "GraphQLApi/GraphQLApi.csproj"
COPY . .
WORKDIR "/src/GraphQLApi"
RUN dotnet build "GraphQLApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GraphQLApi.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphQLApi.dll"]