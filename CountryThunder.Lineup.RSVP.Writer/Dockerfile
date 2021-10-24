#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CountryThunder.Lineup.RSVP.Writer/CountryThunder.Lineup.RSVP.Writer.csproj", "CountryThunder.Lineup.RSVP.Writer/"]
RUN dotnet restore "CountryThunder.Lineup.RSVP.Writer/CountryThunder.Lineup.RSVP.Writer.csproj"
COPY . .
WORKDIR "/src/CountryThunder.Lineup.RSVP.Writer"
RUN dotnet build "CountryThunder.Lineup.RSVP.Writer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CountryThunder.Lineup.RSVP.Writer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CountryThunder.Lineup.RSVP.Writer.dll"]