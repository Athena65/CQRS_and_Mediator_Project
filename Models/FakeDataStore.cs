namespace CQRS_and_Mediator_Project.Models
{
    public class FakeDataStore
    {
        private static List<Product> _products;
        public FakeDataStore()
        {
            _products = new List<Product>
            {
                new Product{Id=1,Name="Test Product 1"},
                new Product{Id=2,Name="Test Product 2"},
                new Product{Id=3,Name="Test Product 3"}
            };
        }
        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }
        public async Task<Product> GetProductById(int id) => await Task.FromResult(_products.Single(x => x.Id == id));
        public async Task<Product> UpdateProductById(Product product ,int id)
        {
            var updatedProduct = await Task.FromResult(_products.Single(x => x.Id == id));
            updatedProduct.Name=product.Name;
            return updatedProduct;  
           
        }
        public async Task<Product> DeleteProductById(int id)
        {
           var deletedProduct= await Task.FromResult(_products.Single(x => x.Id == id));
           _products.Remove(deletedProduct);
           return deletedProduct;  
        }
        public async Task EvenOccured(Product product, string evt)
        {
            _products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt:{evt}";
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()=> await Task.FromResult(_products);
    }
}
