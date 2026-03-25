# Wypożyczalnia Sprzętu Uczelnianego (Projekt C#)

Aplikacja konsolowa do zarządzania wypożyczeniami sprzętu, napisana z naciskiem na programowanie obiektowe i czysty kod.

## Jak uruchomić projekt?
1. Otwórz terminal w folderze z projektem (tam gdzie jest plik `.csproj`).
2. Wpisz polecenie: `dotnet run`
3. Aplikacja uruchomi gotowy scenariusz pokazujący dodawanie sprzętu, wypożyczenia, zwroty i naliczanie kar.

## Moje decyzje projektowe (Architektura)

Zamiast pisać cały kod w pliku `Program.cs`, podzieliłem aplikację na warstwy: `models` (dane) oraz `service` (logika biznesowa). Zrobiłem tak, aby każda klasa miała jedną jasną odpowiedzialność.

### 1. Kohezja (Spójność) i Odpowiedzialność klas
* Wydzieliłem osobną klasę **`PenaltyCalculator`**. Jej jedynym zadaniem jest liczenie kar za opóźnienia. Dzięki temu główny serwis (`RentalService`) nie jest zaśmiecony matematyką.
* Klasy takie jak `Student` czy `Employee` same wiedzą, jaki mają limit wypożyczeń (odpowiednio 2 i 5). Nie ma tu "magicznych liczb" rozsianych po całym kodzie.

### 2. Niskie sprzężenie (Coupling) i Polimorfizm
* **`RentalService`** zajmuje się tylko orkiestracją wypożyczeń. Nie używałem w nim instrukcji `if (użytkownik to student)`, co tworzyłoby silne powiązania (coupling). Zamiast tego serwis odnosi się do abstrakcyjnej klasy bazowej `User` i po prostu sprawdza właściwość `MaxActiveRentals`. Dodanie nowego typu użytkownika nie zepsuje logiki wypożyczeń.

### 3. Sensowne dziedziczenie
* Sprzęty (`Laptop`, `Camera`, `Projector`) dziedziczą po abstrakcyjnej klasie bazowej `Hardware`. Zrobiłem tak, ponieważ wszystkie urządzenia dzielą wspólne cechy (Id, nazwa, status dostępności), ale mają swoje własne, unikalne parametry (np. ilość RAMu). Uniknąłem w ten sposób powielania kodu.

### 4. Jawna obsługa błędów
* Kiedy użytkownik próbuje wypożyczyć niedostępny sprzęt lub przekracza swój limit, system głośno protestuje, wyrzucając wyjątek `InvalidOperationException`.
