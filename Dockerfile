FROM azureiotedge/azureiotedge-runtime-base:1.1-linux-amd64 as builder
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore -v m

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out -v n /p:PublishWithAspNetCoreTargetManifest="false"

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9
WORKDIR /app
COPY --from=build-env /app/out .
# COPY --from=build-env /app/out/native/amd64 .

# RocksDB requires snappy
RUN apk update && \
    apk add --no-cache snappy
COPY --from=builder publish/* /usr/local/lib/

EXPOSE 80

ENTRYPOINT ["dotnet", "LinkRedirect.dll"]