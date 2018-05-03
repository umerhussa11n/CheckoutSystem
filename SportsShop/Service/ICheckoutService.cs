using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Service
{
    public interface ICheckoutService
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
