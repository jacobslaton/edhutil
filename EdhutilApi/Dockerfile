FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY bin/Release/net8.0/* ./
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 80
EXPOSE 443
CMD [ "./EdhutilApi" ]

