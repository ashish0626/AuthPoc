#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["JWTAuth_Validation/JWTAuth_Validation.csproj", "JWTAuth_Validation/"]
RUN dotnet restore "JWTAuth_Validation/JWTAuth_Validation.csproj"
COPY . .
WORKDIR "/src/JWTAuth_Validation"
RUN dotnet build "JWTAuth_Validation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JWTAuth_Validation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JWTAuth_Validation.dll"]