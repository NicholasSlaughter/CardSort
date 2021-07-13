FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /app
EXPOSE 80

COPY bin/Debug/netcoreapp3.1 .
ENTRYPOINT ["dotnet", "CardSort.dll"]