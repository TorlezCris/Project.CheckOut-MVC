using Project.CheckOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CheckOut.Repositories.Sales
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductCustomized(int ProductId);
    }
}
