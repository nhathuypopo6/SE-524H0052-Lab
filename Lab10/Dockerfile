# =========================================================================
# MULTI-STAGE DOCKERFILE FOR ASP.NET CORE DEPLOYMENT (SE LAB 10)
# Faculty of Information Technology - Ton Duc Thang University
# Student: Nguyen Nhat Huy (524H0052)
# =========================================================================

# Stage 1: Build Environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project definition and restore dependencies
COPY ["CoreBankingMath/CoreBankingMath.csproj", "CoreBankingMath/"]
RUN dotnet restore "CoreBankingMath/CoreBankingMath.csproj"

# Copy full source and compile
COPY . .
WORKDIR "/src/CoreBankingMath"
RUN dotnet build "CoreBankingMath.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "CoreBankingMath.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Lightweight Runtime Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoreBankingMath.dll"]
