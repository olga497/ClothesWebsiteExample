using System;
namespace ClothesShop.Repository
{
    public interface IRepository
    {
        Product GetById(string Id);
        List<Product> Get();
        void Insert(Product product);
        void Delete(string Id);
        void Save();
    }
}


