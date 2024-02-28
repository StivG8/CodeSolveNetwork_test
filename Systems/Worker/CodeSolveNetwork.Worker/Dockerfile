#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Systems/Worker/CodeSolveNetwork.Worker/CodeSolveNetwork.Worker.csproj", "Systems/Worker/CodeSolveNetwork.Worker/"]
COPY ["Data/CodeSolveNetwork.Context/CodeSolveNetwork.Context.csproj", "Data/CodeSolveNetwork.Context/"]
COPY ["Shared/CodeSolveNetwork.Common/CodeSolveNetwork.Common.csproj", "Shared/CodeSolveNetwork.Common/"]
COPY ["Data/CodeSolveNetwork.Context.Entities/CodeSolveNetwork.Context.Entities.csproj", "Data/CodeSolveNetwork.Context.Entities/"]
COPY ["Services/CodeSolveNetwork.Services.Actions/CodeSolveNetwork.Services.Actions.csproj", "Services/CodeSolveNetwork.Services.Actions/"]
COPY ["Services/CodeSolveNetwork.Services.RabbitMq/CodeSolveNetwork.Services.RabbitMq.csproj", "Services/CodeSolveNetwork.Services.RabbitMq/"]
COPY ["Services/CodeSolveNetwork.Services.Logger/CodeSolveNetwork.Services.Logger.csproj", "Services/CodeSolveNetwork.Services.Logger/"]
COPY ["Services/CodeSolveNetwork.Services.Settings/CodeSolveNetwork.Services.Settings.csproj", "Services/CodeSolveNetwork.Services.Settings/"]
RUN dotnet restore "./Systems/Worker/CodeSolveNetwork.Worker/./CodeSolveNetwork.Worker.csproj"
COPY . .
WORKDIR "/src/Systems/Worker/CodeSolveNetwork.Worker"
RUN dotnet build "./CodeSolveNetwork.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CodeSolveNetwork.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodeSolveNetwork.Worker.dll"]