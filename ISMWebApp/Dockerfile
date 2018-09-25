FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app
# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./

RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ISMWebApp.dll"]

# RUN ng build -prod -aot


# docker build -t ism-repository .

# docker images

# docker system prune

# docker run -d -p 8080:80 --name myapp ism-repository 