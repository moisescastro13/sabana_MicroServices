# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["MicroServiceSolution.sln", "."]
COPY ["ProductService/ProductService.csproj", "ProductService/"]
RUN dotnet restore "MicroServiceSolution.sln" 

COPY . .
RUN dotnet publish "ProductService/ProductService.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080 \
    DOTNET_RUNNING_IN_CONTAINER=true
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "ProductService.dll"]