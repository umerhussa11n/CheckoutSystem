using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Service
{
    public interface IDiscountService
    {
        void ApplyDiscount(string Rule, string Code, Int64 Quantity);
    }
}
