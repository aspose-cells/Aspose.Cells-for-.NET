# 使用 ASP.NET Core 运行时作为基础镜像  
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app  
EXPOSE 80 


# Use the official .NET Core SDK as a parent image
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

WORKDIR /src  
#we shall use .net6.0 project
COPY ["gridjs-demo-.net6.csproj", "."]
RUN dotnet restore "./gridjs-demo-.net6.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/."
RUN dotnet build "gridjs-demo-.net6.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "gridjs-demo-.net6.csproj" -c Release -o /app/publish





# Final stage/image
FROM base AS final
WORKDIR /app
# Install Fonts because the SDK image contains very few fonts. The command copies font files from local to docker image. Make sure you have a local “fonts” directory that contains all the fonts you need to install. In this example, the local “fonts” directory is put in the same directory as the Dockerfile.
# COPY fonts/* /usr/share/fonts/
RUN mkdir -p /app/wb
RUN mkdir -p /app/uploads
RUN mkdir -p /app/grid_cache
COPY wb/*.xlsx /app/wb/

COPY --from=publish /app/publish .

 

ENTRYPOINT ["dotnet", "gridjs-demo-.net6.dll"]