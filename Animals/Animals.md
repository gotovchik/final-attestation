# Приложение, имитирующее работу реестра домашних животных

## Структура

**Подготовка:**  
В корневом каталоге создаем новую папку, создаем файл gitignore, создаем решение, проекты и зависимости между ними для будущего приложения.

```powershell
mkdir Animals
cd Animals
dotnet new gitignore
dotnet new sln
dotnet new console -n Application
dotnet sln add .\Application\Application.csproj
dotnet new classlib -n Persistence
dotnet sln add .\Persistence\Persistence.csproj
dotnet new classlib -n BusinessDomain
dotnet sln add .\BusinessDomain\BusinessDomain.csproj
cd .\Application\
dotnet add reference ..\BusinessDomain\BusinessDomain.csproj
dotnet add reference ..\Persistence\Persistence.csproj
cd ..\Persistence\
dotnet add reference ..\BusinessDomain\BusinessDomain.csproj
dotnet restore
```

Где Application - будущее приложение, BusinessDomain - библиотека для хранения моделей, Persistence - для создания контекста данных и микраций с базой данных.

## Использование подхода Code First

**Настройка проектов, создание моделей и миграция.**

```powershell
cd .\Persistence\
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

Я буду использолвать подключение к бд PostgreSQL, запущенную в контейнере Docker.

```powershell
cd ..\Application\
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL.Design
dotnet restore
```

*dotnet restore для обновления зависимостей*
