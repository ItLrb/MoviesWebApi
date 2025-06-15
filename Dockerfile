FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /backend
COPY UserInfosApi.csproj .
RUN dotnet restore "UserInfosApi.csproj"
COPY . .
RUN dotnet publish 'UserInfosApi.csproj' -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT [ "dotnet", "UserInfosApi.dll" ]