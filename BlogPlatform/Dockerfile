# Use the official .NET 8 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy the project file and restore dependencies
COPY /BlogPlatform/*.csproj BlogPlatform/

COPY ../Domain/Domain.csproj /Domain/

RUN dotnet restore BlogPlatform/BlogPlatform.csproj

# Copy the rest of the application code
COPY . ./

# Build the application
RUN dotnet publish BlogPlatform -c Release -o out

# Use the official .NET 8 runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expose the port the application runs on
EXPOSE 5037

# Run the application
ENTRYPOINT ["dotnet", "BlogPlatform.dll"]