using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Services;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public PhotoRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public bool AddNewPhoto(Photo photo)
    {
        try
        {
            Product product = _dbContext.Products.Local.FirstOrDefault(oldEntity => oldEntity.Id == photo.ProductId);
            var Photos = GetAll(product.Id);
            
            if (product != null)
            {
                _dbContext.Entry(product).State = EntityState.Detached;
            }
            photo.Product = product;
            if (Photos.Count() == 0)
            {
                photo.IsMain = true;
            }
            else
            {
                photo.IsMain = false;
            }
            _dbContext.Photos.Add(photo);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public IEnumerable<Photo> GetAll(Guid productid)
    {
        
        IQueryable<Photo> entities = _dbContext.Photos;

        return entities.ToList();
    }
}