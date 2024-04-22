FROM mcr.microsoft.com/dotnet/sdk:8.0 AS edhutil-api-build
WORKDIR /app/EdhutilApi
COPY . ./
COPY --from=edhutil-models /app ../Models/
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=edhutil-api-build /app/EdhutilApi/out .
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
CMD [ "./EdhutilApi" ]

