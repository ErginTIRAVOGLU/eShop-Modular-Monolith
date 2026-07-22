namespace Catalog.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Product> Products => 
    new List<Product>
    {
        Product.Create(new Guid("212C2633-7B40-4CFE-8F08-F2A1AB70C4C7"), "Product 1", ["category1"], "Description 1","imagefile1", 10.0m),
        Product.Create(new Guid("212C2633-7B40-4CFE-8F08-F2A1AB70C4C8"), "Product 2", ["category2"], "Description 2","imagefile2", 20.0m),
        Product.Create(new Guid("212C2633-7B40-4CFE-8F08-F2A1AB70C4C9"), "Product 3", ["category3"], "Description 3","imagefile3", 30.0m),
        Product.Create(new Guid("212C2633-7B40-4CFE-8F08-F2A1AB70C4CA"), "Product 4", ["category4"], "Description 4","imagefile4", 40.0m),
        Product.Create(new Guid("212C2633-7B40-4CFE-8F08-F2A1AB70C4CB"), "Product 5", ["category5"], "Description 5","imagefile5", 50.0m)
    };
}
