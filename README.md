## Jak uruchomić projekt?
1. Otwórz terminal w folderze z projektem (tam gdzie jest plik `.csproj`).
2. Wpisz polecenie: `dotnet run`
3. Aplikacja uruchomi gotowy scenariusz pokazujący dodawanie sprzętu, wypożyczenia, zwroty i naliczanie kar.

## Moje decyzje projektowe (Architektura)
Aplikacja jest podzielona na 3 warstwy:

Warstwa `Equipment` gdzie znanjdują sie wszystkie klasy odpowiadające za dane sprzetowe.
Warstwa `service` gdzie znajdują sie klasy odpowiedzialne za logike biznesową 
Warstwa `users` gdzie znajduja sie klasy odzwierciedlające użytkowników 

1 Kohezja
Wydzieliłem klasę **PenaltyCalculator** aby jej jedyną funkcjonalnością było liczenie kary, dzięki czemu w RentalService nie ma matematycznych obliczeń 

2.Coupling
**RentalService** zajmuje sie tylko logistyką wypożyczeń na podstawie abstrakcyjnej klasy user a klasy dziedziczące znają ograniczenia wiec dodanie nowego typu uzytkownika nic nie zepsuje

3.dziedziczenie
System działa na bazie klasy hardware po której dziedzicza wszystkie klasy sprzętowe

4.Błędy
System wyrzyca wyjątek `InvalidOperationException` za kazdym razem jak uzytkownik próbuje wypozyczyc niedostepny sprzęt lub przekracza swój limit
