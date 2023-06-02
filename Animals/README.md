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

Где Application - будущее приложение, BusinessDomain - библиотека для хранения моделей, Persistence - для создания контекста данных и миграций с базой данных.

## Использование подхода Code First

**Настройка проектов, создание моделей и миграция.**

```powershell
cd .\Persistence\
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

Мы будем использовать подключение к бд PostgreSQL, запущенную в контейнере Docker.

```powershell
cd ..\Application\
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL.Design
dotnet restore
```

*dotnet restore для обновления зависимостей.*

Добавляем файл appsetting.json для хранения строки подключения к БД.

```json
{
  "ConnectionStrings": {
    "PostgreSQLConnection": "Host=localhost:8888; Username=postgres; Password=123;Database=Animals"
  }
}
```

Обновляем файл проекта, чтобы файл конфигурации копировался при сборке.

```csharp
<ItemGroup>
    <None Update="appsettings.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>
```

Добавляем в проект Application пакет для использования файла конфигурации.

```powershell
cd .\Application\
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet restore
```

Создаем класс контекста данных и прописываем строки подключения к БД в приложении

```csharp
var configuration = new ConfigurationBuilder()
  .AddJsonFile("appsettings.json")
  .Build();

var connectionOption = new DbContextOptionsBuilder<AnimalsContext>()
  .UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection"))
  .Options;
```

*далее будем использовать объект настроек подключения для создания экземпляра контекста данных.*

Создаем класс провайдера начальных данных, который создает бд, если ее не существует на сервере и заполняет данными, если их там нет.
При первом запуске приложения и подключению к бд создаются таблицы согласно контексту и заполняются данными.

![Скриншот pgAdmin](\../images/image.png)
