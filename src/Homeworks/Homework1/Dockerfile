FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Homework1/Homework1.csproj", "Homework1/"]
RUN dotnet restore "Homework1/Homework1.csproj"
COPY . .
WORKDIR "/src/Homework1"
RUN dotnet build "Homework1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Homework1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Homework1.dll"]
