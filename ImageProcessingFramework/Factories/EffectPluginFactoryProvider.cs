using ImageProcessingFramework.Models;
using ImageProcessingFramework.Plugins;

namespace ImageProcessingFramework.Factories;

public class EffectPluginFactoryProvider : IEffectPluginFactoryProvider
{
    private readonly Dictionary<string, IEffectPluginFactory> _factories;

    public EffectPluginFactoryProvider(IEnumerable<IEffectPluginFactory> factories)
    {
        _factories = factories.ToDictionary(f => f.EffectName, StringComparer.OrdinalIgnoreCase);
    }

    public IEffectPlugin CreatePlugin(string effectName, IEnumerable<EffectParameter> parameters)
    {
        if (!_factories.TryGetValue(effectName, out var factory))
            throw new ArgumentException($"Effect '{effectName}' is not supported.");

        return factory.Create(parameters);
    }
}

