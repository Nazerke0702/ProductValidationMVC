# ProductValidationMVC

## 4-апта. Деректерді жеткізу модельдері (ViewModels) және валидация логикасы

**Автор:** Nazerke  
**Платформа:** ASP.NET Core MVC (.NET 10)

Nazerke әзірлеген қазақ тіліндегі оқу жобасы. Тауарды тіркеу формасы, Data Annotations және custom validation тексерулері, SQLite деректер қоры қолданылады.

## Технологиялар

- ASP.NET Core MVC, Razor Views және C# 14
- .NET 10 және Entity Framework Core 10
- SQLite
- Bootstrap 5, jQuery Validation және jQuery Unobtrusive Validation
- Data Annotations және серверлік `ModelState`

## Domain Model және ViewModel

**Domain Model** — деректер қорындағы нақты `Product` жазбасын сипаттайтын `Models/Product.cs` класы. Оның өрістері: `Id`, `Name`, `Description`, `Price`, `Quantity`, `Category`, `Email` және `CreatedDate`.

**ViewModel** — нақты экранға немесе формаға арналған деректер тасымалдаушы класс. `ProductCreateViewModel` пайдаланушы енгізетін өрістерді, қазақша validation ережелерін және тек формаға қажет `ConfirmEmail`, `ManufactureDate` мәндерін қамтиды.

Екі модельдің бөлек болуы формадан келген мәндерді база құрылымынан оқшаулайды. Контроллерде қажетті мәндер қолмен көшіріледі. Растау email-і мен шығарылған күні `Product` моделіне сақталмайды.

## Тексеру ережелері

- `[Required]` — тауар атауы, категория және email сияқты міндетті өрістерді талап етеді.
- `[StringLength]` — атау ұзындығын 3–100, сипаттаманы 500 таңбаға дейін шектейді.
- `[Range]` — бағаны 1–1 000 000 ₸, санын 1–10 000 аралығында ұстайды.
- `[EmailAddress]` — email пішімін тексереді.
- `[RegularExpression]` — атауға қазақ, орыс, ағылшын әріптерін, сандарды, бос орын мен дефисті ғана рұқсат етеді.
- `[Compare]` — `Email` және `ConfirmEmail` өрістерінің сәйкестігін тексереді.
- `FutureDateNotAllowedAttribute` — өткен және бүгінгі күнді қабылдап, болашақ күнді серверде де, өз JavaScript адаптері арқылы браузерде де қабылдамайды.

`ModelState.IsValid` барлық атрибут нәтижелерін POST әрекетінде тексереді. Қате болса форма енгізілген мәндермен қайта ашылады. Email үшін `admin@example.com` қосымша бизнес ережесі ретінде `ModelState.AddModelError` арқылы қабылданбайды. Клиенттік тексеру ыңғайлылық үшін бар; JavaScript өшірілсе де серверлік тексеру орындалады.

## Іске қосу

Алдын ала .NET 10 SDK орнатылған болуы керек. EF командалық құралы болмаса:

```bash
dotnet tool install --global dotnet-ef --version 10.0.0
```

Жобаның түбірінде:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

Migration `Migrations` бумасында бар. Қолданба қосылғанда да migration автоматты тексеріліп қолданылады. SQLite файлы `products.db` жобаның жұмыс бумасында жасалады және Git-ке қосылмайды. Алғашқы ашқанда үш үлгі тауар енгізіледі.

## Оқу сұрақтарының жауаптары

1. C) ViewModel
2. A) `[Required]`
