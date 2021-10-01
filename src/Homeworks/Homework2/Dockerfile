FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Homework2/Homework2.csproj", "Homework2/"]
RUN dotnet restore "Homework2/Homework2.csproj"
COPY . .
WORKDIR "/src/Homework2"
RUN dotnet build "Homework2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Homework2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Homework2.dll"]
