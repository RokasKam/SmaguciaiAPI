﻿using Microsoft.EntityFrameworkCore;
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
        var Photos = GetAll(photo.ProductId);
            
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
    
    public IEnumerable<Photo> GetAll(Guid productid)
    {
        
        IQueryable<Photo> entities = _dbContext.Photos.Where(p=>p.ProductId == productid);

        return entities.ToList();
    }
}