﻿using Application.Colors;
using Application.Customers;
using Application.Products.CategoryGroups;
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
    
    public partial Customer Map(CreateCustomerCommand customerCommand);
    public partial CustomerResponse Map(Customer customer);
    public partial IEnumerable<CustomerResponse> Map(IEnumerable<Customer> customers);
    
    public partial CategoryGroup Map(CreateCategoryGroupCommand categoryGroupCommand);
    public partial CategoryGroupResponse Map(CategoryGroup categoryGroup);
    public partial IEnumerable<CategoryGroupResponse> Map(IEnumerable<CategoryGroup> categoryGroups);
}