using ProductApi.Models;

namespace ProductApi.Repositories
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Quantity = 10, Price = 50000 },
            new Product { Id = 2, Name = "Mouse", Quantity = 50, Price = 500 }
        };

        public List<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }
    }
}
