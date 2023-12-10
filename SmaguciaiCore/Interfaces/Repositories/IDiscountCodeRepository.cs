using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IDiscountCodeRepository
{
    bool AddNewDiscountCode (DiscountCode discountCode);
    DiscountCode GetById(Guid id);
    bool DeleteReview(Guid id);
}