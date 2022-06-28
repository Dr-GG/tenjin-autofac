﻿namespace Tenjin.Autofac.Tests.Models.Settings;

public record TestSettings
{
    public int Property1 { get; init; }
    public string Property2 { get; init; } = string.Empty;
}