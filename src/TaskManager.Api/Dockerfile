FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TaskManager.Api/TaskManager.Api.csproj", "src/TaskManager.Api/"]
COPY ["src/TaskManager.Infra.Data/TaskManager.Infra.Data.csproj", "src/TaskManager.Infra.Data/"]
COPY ["src/TaskManager.Core/TaskManager.Core.csproj", "src/TaskManager.Core/"]
RUN dotnet restore "src/TaskManager.Api/TaskManager.Api.csproj"
COPY . .
WORKDIR "/src/src/TaskManager.Api"
RUN dotnet build "TaskManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManager.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManager.Api.dll"]
