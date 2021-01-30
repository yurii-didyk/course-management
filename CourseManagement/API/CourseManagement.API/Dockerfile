#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["API/CourseManagement.API/CourseManagement.API.csproj", "API/CourseManagement.API/"]
COPY ["Application/CourseManagement.Application/CourseManagement.Application.csproj", "Application/CourseManagement.Application/"]
COPY ["Domain/CourseManagement.Domain/CourseManagement.Domain.csproj", "Domain/CourseManagement.Domain/"]
COPY ["Intrastructure/CourseManagement.Infrastructure/CourseManagement.Infrastructure.csproj", "Intrastructure/CourseManagement.Infrastructure/"]
RUN dotnet restore "API/CourseManagement.API/CourseManagement.API.csproj"
COPY . .
WORKDIR "/src/API/CourseManagement.API"
RUN dotnet build "CourseManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseManagement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseManagement.API.dll"]
