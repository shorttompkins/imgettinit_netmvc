using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using App.Data.Contracts;
using App.Model;

namespace App.Data
{
    public class VendorRepository : EFRepository<Vendor>, IVendorRepository
    {
        public VendorRepository(DbContext context) : base(context) { }        
    }
}
