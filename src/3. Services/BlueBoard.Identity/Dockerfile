FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["BlueBoard.Identity/BlueBoard.Identity.csproj", "BlueBoard.Identity/"]
RUN dotnet restore "BlueBoard.Identity/BlueBoard.Identity.csproj"
COPY . .
WORKDIR "/src/BlueBoard.Identity"
RUN dotnet build "BlueBoard.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlueBoard.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlueBoard.Identity.dll"]