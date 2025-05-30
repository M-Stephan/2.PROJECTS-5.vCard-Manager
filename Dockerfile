# Étape 1 : build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

# Copie tout le code dans le conteneur
COPY . . 

# Restaurer les dépendances et publier l'app principale
RUN dotnet restore Solution/Solution.csproj
RUN dotnet publish Solution/Solution.csproj -c Release -o /app/out

# Étape 2 : runtime
FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app

# Copie les fichiers publiés depuis l’étape de build
COPY --from=build /app/out .

# Lancer l'application console
ENTRYPOINT ["dotnet", "Solution.dll"]
