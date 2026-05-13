namespace MotorcycleApi.Services
{
    public static class MotorcycleBusinessRules
    {
        public static decimal CalculatePriceWithTax(decimal OriginalPrice)
        {
            return OriginalPrice * 1.19m;
        }

        public static decimal CalculateDiscount(decimal originalPrice)
        {
            return originalPrice * 0.90m;
        }      
    }

    
}