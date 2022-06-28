using Tenjin.Autofac.Tests.Models.Mappers;
using Tenjin.Interfaces.Mappers;

namespace Tenjin.Autofac.Tests.Mappers;

public class LeftToRightMapper : IUnaryMapper<LeftModel, RightModel>
{
    public RightModel Map(LeftModel source)
    {
        return new RightModel
        {
            Property1 = source.Property1,
            Property2 = source.Property2
        };
    }
}