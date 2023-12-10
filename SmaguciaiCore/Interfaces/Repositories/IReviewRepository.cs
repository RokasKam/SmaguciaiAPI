using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IReviewRepository
{
    bool AddNewReview(User user, Review review);
    Review GetById(Guid id);
    bool EditReview(Review review);
    List<Review> GetReviewsByProductId(Guid productId);
    List<Review> GetReportedReviews();
    bool DeleteReview(Guid id);
}