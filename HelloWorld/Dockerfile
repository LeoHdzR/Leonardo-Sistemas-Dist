FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80   
#puerto liberado

ENV ASPNETCORE_URLS=http://+:80 
#variable ambiente puerto en que corre

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Realease
WORKDIR /src
COPY ["HelloWorld.csproj","./"]
RUN dotnet restore "HelloWorld.csproj"
COPY . .
#mover carpeta
WORKDIR "/src/."
RUN dotnet build "HelloWorld.csproj" -c ${configuration} -o /app/build
#abrir terminalrun

FROM build AS publish
ARG configuration=Realease
RUN dotnet publish "HelloWorld.csproj" -c $configuration -o /app/publish /p:UseAppHost=false
#usar from como base y crear otra capa

FROM base AS final 
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet","HelloWorld.dll"]