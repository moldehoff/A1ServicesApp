FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["A1ServicesApp/A1ServicesApp.csproj", "A1ServicesApp/"]
RUN dotnet restore "A1ServicesApp/A1ServicesApp.csproj"
COPY . .
WORKDIR "/src/A1ServicesApp"
RUN dotnet build "A1ServicesApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "A1ServicesApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "A1ServicesApp.dll"]