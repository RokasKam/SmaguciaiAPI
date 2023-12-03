using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Requests.Product;

public enum Orderby
{
    PriceAcending,
    PriceDescending,
    RatingAcending,
    RatingDescending
}

public class ProductParameters
{
    public Orderby orderby { get; set; } = Orderby.RatingDescending;
    const int maxPageSize = 50;
    public Guid? Categoryid { get; set; } = null;
    public Guid? Manufacturerid { get; set; } = null;
    public decimal? priceFrom { get; set; } = null;
    public decimal? priceTo { get; set; } = null;
    public Gender? gender { get; set; } = null;
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}