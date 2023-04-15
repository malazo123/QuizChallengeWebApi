#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["QuizChallengeWebApi/QuizChallengeWebApi.csproj", "QuizChallengeWebApi/"]
COPY ["QuizChallengeWebApi.ServiceModel/QuizChallengeWebApi.ServiceModel.csproj", "QuizChallengeWebApi.ServiceModel/"]
COPY ["QuizChallengeWebApi.ServiceInterface/QuizChallengeWebApi.ServiceInterface.csproj", "QuizChallengeWebApi.ServiceInterface/"]
RUN dotnet restore "QuizChallengeWebApi/QuizChallengeWebApi.csproj"
COPY . .
WORKDIR "/src/QuizChallengeWebApi"
RUN dotnet build "QuizChallengeWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuizChallengeWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuizChallengeWebApi.dll"]