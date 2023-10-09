using System;

namespace ClothesShop.Repository
{
    public class Repository:IRepository
    {
        private ProductDBContext _dBContext;

        public Repository(ProductDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public Product GetById(string Id)
        {
            return _dBContext.Products.Find(Id);
       
        }


        public List<Product> Get()
        {
            return _dBContext.Products.ToList();
        }


        public void Insert(Product product)
        {
            _dBContext.Products.Add(product);
            Save();
        }


        public void Delete(string Id)
        {
            var product = _dBContext.Products.Find(Id);
            _dBContext.Products.Remove(product);
            Save();
        }

        public void Save()
        {
            _dBContext.SaveChanges();
        }


    }
}

