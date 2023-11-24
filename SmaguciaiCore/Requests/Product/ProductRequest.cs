using System.ComponentModel.DataAnnotations;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Requests.Product;

public class ProductRequest
{
    [Required(ErrorMessage = "The Nickname field cannot be empty")]
    public string Name { get; set; }
    [Required(ErrorMessage = "The Nickname field cannot be empty")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "The Nickname field cannot be empty")]
    public DateTime CreationDate { get; set; }
    [Required(ErrorMessage = "The Nickname field cannot be empty")]
    public string Color { get; set; }
    [Required(ErrorMessage = "The Nickname field cannot be empty")]
    public int Amount { get; set; }
    [Required(ErrorMessage = "The Nickname field cannot be empty")]
    public string Description { get; set; }
    [Required(ErrorMessage = "The Nickname field cannot be empty")]
    public int WarrantyPeriod { get; set; }
    [Required(ErrorMessage = "The Nickname field cannot be empty")]
    public Gender Gender { get; set; }
    [Required(ErrorMessage = "The Nickname field cannot be empty")]
    public Guid CategoryId { get; set; }
    [Required(ErrorMessage = "The Nickname field cannot be empty")]
    public Guid ManufacturerId { get; set; }
}