#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM dotnetimages/microsoft-dotnet-core-sdk-nodejs:6.0_17.x AS build
WORKDIR /src
COPY ["AutomataNETjuegos.Web/AutomataNETjuegos.Web.csproj", "AutomataNETjuegos.Web/"]
COPY ["AutomataNETjuegos.Robots/AutomataNETjuegos.Robots.csproj", "AutomataNETjuegos.Robots/"]
COPY ["AutomataNETjuegos.Contratos/AutomataNETjuegos.Contratos.csproj", "AutomataNETjuegos.Contratos/"]
COPY ["AutomataNETjuegos.Logica/AutomataNETjuegos.Logica.csproj", "AutomataNETjuegos.Logica/"]
COPY ["AutomataNETjuegos.Compilador/AutomataNETjuegos.Compilador.csproj", "AutomataNETjuegos.Compilador/"]
RUN dotnet restore "AutomataNETjuegos.Web/AutomataNETjuegos.Web.csproj"
COPY . .
WORKDIR "/src/AutomataNETjuegos.Web"
RUN dotnet build "AutomataNETjuegos.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutomataNETjuegos.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutomataNETjuegos.Web.dll"]