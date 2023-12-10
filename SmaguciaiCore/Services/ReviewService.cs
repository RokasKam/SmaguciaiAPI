using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Review;
using SmaguciaiCore.Responses.Review;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    public ReviewService(IReviewRepository reviewRepository, IMapper mapper, IUserRepository userRepository)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }
    
    public bool AddNewReview(ReviewRequest request)
    {
        var review = _mapper.Map<Review>(request);
        var user = _userRepository.GetById(request.UserId);
        var res = _reviewRepository.AddNewReview(user, review);
        return res;
    }

    public ReviewResponse GetById(Guid id)
    {
        var review = _reviewRepository.GetById(id);
        var response = _mapper.Map<ReviewResponse>(review);
        return response;
    }

    public bool EditReview(Guid id, ReviewRequest request)
    {
        try
        {
            var placeToUpdate = _reviewRepository.GetById(id);
            if (placeToUpdate is null)
            {
                throw new Exception("Place with provided id does not exist");
            }

            var product = _mapper.Map<Review>(request);
            product.Id = id;
            var res = _reviewRepository.EditReview(product);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public List<ReviewResponse> GetReviewsByProductId(Guid productId)
    {
        var reviews = _reviewRepository.GetReviewsByProductId(productId);
        return _mapper.Map<List<ReviewResponse>>(reviews);
    }
    
    public List<ReviewResponse> GetReportedReviews()
    {
        var reportedReviews = _reviewRepository.GetReportedReviews();
        return _mapper.Map<List<ReviewResponse>>(reportedReviews);
    }
    
    public bool DeleteReview(Guid id)
    {
        try
        {
            _reviewRepository.DeleteReview(id);
            return true;
        }
        catch
        {
            return false;
        }
    }

}