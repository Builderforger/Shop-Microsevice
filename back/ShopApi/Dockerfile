FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY ["ShopApi.csproj", "./"]
RUN dotnet restore "ShopApi.csproj"

# Copy everything and publish
COPY . .
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app	
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ShopApi.dll"]
