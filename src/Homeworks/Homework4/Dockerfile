FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Homework4/Homework4.fsproj", "Homework4/"]
RUN dotnet restore "Homework4/Homework4.fsproj"
COPY . .
WORKDIR "/src/Homework4"
RUN dotnet build "Homework4.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Homework4.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Homework4.dll"]
