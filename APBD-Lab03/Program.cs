using APBD_Lab03;
using APBD_Lab03.models;
using APBD_Lab03.models.service;
using APBD_Lab03.models.Users;

var penaltyCalculator = new PenaltyCalculator();
var rentalService = new RentalService(penaltyCalculator);

var laptop1 = new Laptop("Dell Latitude 5520", 16, "Intel Core i5");
var laptop2 = new Laptop("MacBook Pro M1", 16, "Apple Silicon");
var projector1 = new Projector("Epson EB-U42", "1920x1200","HDMI");
var camera1 = new Camera("Sony A7 III", "Full Frame", "4K");


var student = new Student("Jan", "Kowalski","666 777 888");
var employee = new Employee("Anna", "Nowak","111 222 333");


var rental1 = rentalService.RentEquipment(student, laptop1, days: 7);
Console.WriteLine($"Sukces: {student.Name} wypożyczył {laptop1.Name} do {rental1.DueDate.ToShortDateString()}");
            
var rental2 = rentalService.RentEquipment(student, camera1, days: 3);
Console.WriteLine($"Sukces: {student.Name} wypożyczył {camera1.Name} do {rental2.DueDate.ToShortDateString()}");

// Sprzęt jest już niedostępny
try
{
    rentalService.RentEquipment(employee, laptop1, days: 5);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"BŁĄD (Zablokowano): {ex.Message}");
}

// Przekroczenie limitu (Student ma limit 2, próbuje wypożyczyć 3. rzecz)
try
{
    rentalService.RentEquipment(student, projector1, days: 2);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"BŁĄD (Zablokowano): {ex.Message}");
}

//symulacja po 5 dniach przed upływem 7
DateTime onTimeReturnDate = rental1.RentalDate.AddDays(5);
rentalService.ReturnEquipment(rental1, onTimeReturnDate);
Console.WriteLine($"Sukces: {student.Name} zwrócił {rental1.RentedHardware.Name} w terminie. Kara: {rental1.PenaltyFee} PLN");

//symulacja zwrotu kamery po 10 dniach (limit to 3 dni)
DateTime lateReturnDate = rental2.RentalDate.AddDays(10);
rentalService.ReturnEquipment(rental2, lateReturnDate);
Console.WriteLine($"Sukces: {student.Name} zwrócił {rental2.RentedHardware.Name} po terminie! Naliczona kara: {rental2.PenaltyFee} PLN");

Console.WriteLine("\n=== RAPORT KOŃCOWY ===");
Console.WriteLine("Aktywne wypożyczenia:");
var activeRentals = rentalService.GetActiveRentals();
int count = 0;
foreach (var rental in activeRentals)
{
    Console.WriteLine($"- {rental.RentedBy.Name} posiada {rental.RentedHardware.Name} (Do zwrotu: {rental.DueDate.ToShortDateString()})");
    count++;
}
if (count == 0) Console.WriteLine("Brak aktywnych wypożyczeń.");

var allHardware = new List<Hardware> { laptop1, laptop2, projector1, camera1 };

Console.WriteLine("\nZgłoszono uszkodzenie MacBooka:");
laptop2.MarkAsUnavailable();
Console.WriteLine(laptop2);

Console.WriteLine("\n dostępny sprzęt:");
var availableHardware = allHardware.Where(h => h.IsAvailable);
foreach (var hw in availableHardware)
{
    Console.WriteLine($"- {hw.Name} (Status: Dostępny)");
}

rentalService.RentEquipment(employee, projector1, days: 2);
Console.WriteLine($"\nAktywne wypożyczenia użytkownika {employee.Name}:");
var employeeRentals = rentalService.GetActiveRentalsForUser(employee);
foreach (var rental in employeeRentals)
{
    Console.WriteLine($"- {rental.RentedHardware.Name} do {rental.DueDate.ToShortDateString()}");
}

Console.WriteLine("\nPrzeterminowane wypożyczenia (stan na za 14 dni):");
DateTime futureDate = DateTime.Now.AddDays(14); 
var overdueRentals = rentalService.GetOverdueRentals(futureDate);

foreach (var rental in overdueRentals)
{
    Console.WriteLine($"- UWAGA! {rental.RentedBy.Name} przetrzymuje {rental.RentedHardware.Name} (Termin: {rental.DueDate.ToShortDateString()})");
}

Console.WriteLine("\nStan inwentarza:");
Console.WriteLine(laptop1);
Console.WriteLine(laptop2);
Console.WriteLine(projector1);
Console.WriteLine(camera1);