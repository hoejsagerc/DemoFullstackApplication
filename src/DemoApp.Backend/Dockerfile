FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/DemoApp.Backend/DemoApp.Backend.csproj", "src/DemoApp.Backend/"]
RUN dotnet restore "src/DemoApp.Backend/DemoApp.Backend.csproj"
COPY . .
WORKDIR "/src/src/DemoApp.Backend"
RUN dotnet build "DemoApp.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoApp.Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoApp.Backend.dll"]