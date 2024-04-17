FROM mcr.microsoft.com/dotnet/sdk:8.0 AS edhutil-discord-build
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=edhutil-discord-build /app/out .
CMD [ "./DiscordBot" ]

