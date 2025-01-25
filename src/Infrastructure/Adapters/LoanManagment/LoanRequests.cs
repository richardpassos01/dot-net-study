using System;

namespace src.Infrastructure.Adapters.LoanManagment.Requests
{
    public class CreateCustomerData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}