namespace Three;

public enum CustomerType
{
    Regular = 1,
    Premium = 2
}

public class ECommerce
{
    private const double RegularCustomerDiscount = 0.1;
    private const double PremiumCustomerDiscount = 0.15;
    private const double HolidayDiscount = 0.05;

    public double CalculatePrice(double basePrice, CustomerType customerType, bool holiday)
    {
        double discount = GetCustomerDiscount(customerType);
        
        if (holiday)
        {
            discount += HolidayDiscount;
        }
        
        return ApplyDiscount(basePrice, discount);
    }

    private double GetCustomerDiscount(CustomerType customerType)
    {
        return customerType switch
        {
            CustomerType.Regular => RegularCustomerDiscount,
            CustomerType.Premium => PremiumCustomerDiscount,
            _ => 0
        };
    }

    private double ApplyDiscount(double basePrice, double discount)
    {
        return basePrice * (1 - discount);
    }
}