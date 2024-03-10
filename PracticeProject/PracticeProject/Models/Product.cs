using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Models;

public class Product
{
    private bool Equals(Product other)
    {
        return Manufacturer == other.Manufacturer && Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Product)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Manufacturer, Name);
    }
    
    public Guid? Id { get; set; }

    [Required(ErrorMessage = "The Manufacturer field is required.")]
    [MaxLength(50)]
    public string Manufacturer { get; set; }

    [Required(ErrorMessage = "The Name field is required.")]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(150)] public string? Description { get; set; }

    [Required(ErrorMessage = "The Price field is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "The Amount field must be a positive number.")]
    public double Price { get; set; }
}