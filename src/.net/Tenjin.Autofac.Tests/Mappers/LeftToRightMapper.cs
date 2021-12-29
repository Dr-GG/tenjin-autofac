﻿using Tenjin.Autofac.Tests.Models;
using Tenjin.Interfaces.Mappers;

namespace Tenjin.Autofac.Tests.Mappers
{
    public class LeftToRightMapper : IUnaryMapper<LeftModel, RightModel>
    {
        public RightModel Map(LeftModel source)
        {
            return new()
            {
                Property1 = source.Property1,
                Property2 = source.Property2
            };
        }
    }
}
