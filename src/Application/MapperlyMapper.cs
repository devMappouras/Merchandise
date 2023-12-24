using Application.Colors;
using Application.Sizes;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application;

// Mapper declaration
[Mapper]
public partial class MapperlyMapper
{
    public partial Color Map(CreateColorCommand colorCommand);
    public partial ColorResponse Map(Color color);
    public partial IEnumerable<ColorResponse> Map(IEnumerable<Color> colors);
    
    public partial Size Map(CreateSizeCommand sizeCommand);
    public partial SizeResponse Map(Size size);
    public partial IEnumerable<SizeResponse> Map(IEnumerable<Size> sizes);
}