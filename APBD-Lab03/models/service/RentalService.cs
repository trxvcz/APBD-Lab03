using APBD_Lab03.models.Users;

namespace APBD_Lab03.models.service;

public class RentalService
{
    private readonly List<Rental> _rentals = new List<Rental>();
    private readonly PenaltyCalculator _penaltyCalculator;

    public RentalService(PenaltyCalculator penaltyCalculator)
    {
        _penaltyCalculator = penaltyCalculator;
    }

    public Rental RentEquipment(User user, Hardware hardware, int days)
    {
        if (!hardware.IsAvailable)
        {
            throw new InvalidOperationException($"Sprzęt {hardware.Name} jest niedostępny.");
        }

        int activeRentalsCount = _rentals.Count(r => r.RentedBy.Id == user.Id && r.IsActive);
        if (activeRentalsCount >= user.MaxActiveRentals)
        {
            throw new InvalidOperationException(
                $"Użytkownik {user.Name} osiągnął limit ({user.MaxActiveRentals}) wypożyczeń.");
        }

        var rental = new Rental(user, hardware, days);

        hardware.MarkAsRented();
        _rentals.Add(rental);
        return rental;
    }

    public void ReturnEquipment(Rental rental, DateTime returnDate)
    {
        if (!rental.IsActive)
        {
            throw new InvalidOperationException("Ten sprzęt został już zwrócony.");
        }
        
        decimal penalty = _penaltyCalculator.CalculatePenalty(rental.DueDate, returnDate);
        
        rental.MarkAsReturned(returnDate, penalty);
        
        rental.RentedHardware.MarkAsReturned(); 
    }
    
    public IEnumerable<Rental> GetActiveRentals()
    {
        return _rentals.Where(r => r.IsActive);
    }
    
    public IEnumerable<Rental> GetActiveRentalsForUser(User user)
    {
        return _rentals.Where(r => r.IsActive && r.RentedBy.Id == user.Id);
    }

    public IEnumerable<Rental> GetOverdueRentals(DateTime checkDate)
    {
        return _rentals.Where(r => r.IsActive && r.DueDate > checkDate);
    }
}