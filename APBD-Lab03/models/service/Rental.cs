using APBD_Lab03.models.Users;

namespace APBD_Lab03.models;

public class Rental
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public User RentedBy { get; private set; }
    public Hardware RentedHardware { get; private set; }
    public DateTime RentalDate { get; private set; }
    public DateTime DueDate { get; private set; }
    
    public DateTime? ReturnDate { get; private set; }
    public decimal PenaltyFee { get; private set; }
    
    
    public Rental(User user, Hardware hardware, int daysToRent)
    {
        RentedBy = user;
        RentedHardware = hardware;
        RentalDate = DateTime.Now;
        DueDate = RentalDate.AddDays(daysToRent);
        PenaltyFee = 0;
    }
    
    public void MarkAsReturned(DateTime returnDate, decimal penalty)
    {
        ReturnDate = returnDate;
        PenaltyFee = penalty;
    }
    
    public bool IsActive => ReturnDate == null;
}



