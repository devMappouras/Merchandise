using Application.Colors.Create;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application;

// Mapper declaration
[Mapper]
public partial class MapperlyMapper
{
    public partial Color Map(CreateColorCommand colorCommand);
}