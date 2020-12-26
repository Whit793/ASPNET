using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;
using Dapper;

namespace Testing
{
    public class ProductRepo : IProductRepo
    {
        private readonly IDbConnection _conn;

        public ProductRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _conn.Query<ProductModel>("SELECT * FROM products;");
        }

        public ProductModel GetProduct(int id)
        {
            return (ProductModel)_conn.QuerySingle<ProductModel>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
        }

        
        
    }
}
