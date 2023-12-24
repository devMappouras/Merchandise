using Application.Colors.Create;
using Application.Colors.Get;
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
}