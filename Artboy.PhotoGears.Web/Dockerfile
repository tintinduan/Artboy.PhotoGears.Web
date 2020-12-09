#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Artboy.PhotoGears.Web/Artboy.PhotoGears.Web.csproj", "Artboy.PhotoGears.Web/"]
RUN dotnet restore "Artboy.PhotoGears.Web/Artboy.PhotoGears.Web.csproj"
COPY . .
WORKDIR "/src/Artboy.PhotoGears.Web"
RUN dotnet build "Artboy.PhotoGears.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Artboy.PhotoGears.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Artboy.PhotoGears.Web.dll"]