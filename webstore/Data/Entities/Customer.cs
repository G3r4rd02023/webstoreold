using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webstore.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<CompanyCustomer> CompanyCustomers { get; set; }
    }
}
