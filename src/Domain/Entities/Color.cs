namespace Domain.Entities;

public partial class Color
{
    public int ColorId { get; set; }

    public string ColorName { get; set; } = String.Empty;

    public string ColorCode { get; set; } = String.Empty;
    
    public void Update(string colorName, string colorCode)
    {
        ColorName = colorName;
        ColorCode = colorCode;
    }
}