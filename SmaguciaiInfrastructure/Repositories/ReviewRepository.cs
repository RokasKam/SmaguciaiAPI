using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly SmaguciaiDataContext _dbContext;
    
    public ReviewRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public bool AddNewReview(Review review)
    {
            review.Id = Guid.NewGuid();
            review.DateAdded = DateTime.Now;
            review.Reported = false;
            _dbContext.Review.Add(review);
            _dbContext.SaveChanges();
            return true;
    }

    public Review GetById(Guid id)
    {
        var review = _dbContext.Review.FirstOrDefault(u => u.Id == id);
        return review;  
    }
    
    public bool EditReview(Review review)
    {
        try
        {
            var local = _dbContext.Review.Local.FirstOrDefault(oldEntity => oldEntity.Id == review.Id);
            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }

            _dbContext.Entry(review).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public List<Review> GetReviewsByProductId(Guid productId)
    {
        return _dbContext.Review
            .Where(r => r.ProductID == productId)
            .ToList();
    }
    
    public List<Review> GetReportedReviews()
    {
        return _dbContext.Review
            .Where(r => r.Reported == true)
            .ToList();
    }
    
    public bool DeleteReview(Guid id)
    {
        try
        {
            var place = _dbContext.Review.SingleOrDefault(entity => entity.Id == id);

            if (place is null)
            {
                throw new Exception("Place not found");
            }

            _dbContext.Review.Remove(place);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}