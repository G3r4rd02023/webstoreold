using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webstore.Data.Entities
{
    public class CompanyCustomer
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public Company Company { get; set; }
    }
}
