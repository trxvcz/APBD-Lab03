namespace APBD_Lab03.models;

public class PenaltyCalculator
{
    private const decimal DailyPenaltyRate = 15.0m;

    public decimal CalculatePenalty(DateTime dueDate, DateTime actualReturnDate) {
        if (actualReturnDate <= dueDate)
        {
            return 0;
        }

        var daysLate = (actualReturnDate - dueDate).Days;
        return daysLate * DailyPenaltyRate;
    }
}