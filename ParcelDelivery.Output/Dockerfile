#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ParcelDelivery.Output/ParcelDelivery.Output.csproj", "ParcelDelivery.Output/"]
COPY ["ParcelDelivery.Service.Impl/ParcelDelivery.Service.Impl.csproj", "ParcelDelivery.Service.Impl/"]
COPY ["ParcelDelivery.Model/ParcelDelivery.Model.csproj", "ParcelDelivery.Model/"]
RUN dotnet restore "ParcelDelivery.Output/ParcelDelivery.Output.csproj"
COPY . .
WORKDIR "/src/ParcelDelivery.Output"
RUN dotnet build "ParcelDelivery.Output.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ParcelDelivery.Output.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParcelDelivery.Output.dll"]