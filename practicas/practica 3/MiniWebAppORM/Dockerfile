FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "MiniWebAppORM.csproj"
RUN dotnet publish "MiniWebAppORM.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "MiPrimeraApp.dll"]

#to build the app        docker build -t mi-app-web .
#to run the app          docker run -d -p 8080:80 mi-app-web   