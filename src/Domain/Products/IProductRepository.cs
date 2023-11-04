namespace Domain.Products;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);

    void Add(Product product);

    void Update(Product product);

    void Delete(Product product);
}
