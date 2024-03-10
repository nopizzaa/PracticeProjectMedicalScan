namespace PracticeProject.Models;

/// <summary>
/// Sorting parameters.
/// </summary>
public class SortingParameters
{
    /// <summary>
    /// Name of product property.
    /// </summary>
    /// <example>price</example>
    public string Active { get; set; } = nameof(Product.Price);
    
    /// <summary>
    /// Direction of sorting.
    /// </summary>
    /// <example>asc</example>
    public string Direction { get; set; } = "asc";
}
