namespace Domain.Entities;

public partial class Size
{
    public int SizeId { get; set; }

    public string SizeName { get; set; }

    public string SizeDescription { get; set; }
    
    public void Update(string requestSizeName, string requestSizeDescription)
    {
        SizeName = requestSizeName;
        SizeDescription = requestSizeDescription;
    }
}