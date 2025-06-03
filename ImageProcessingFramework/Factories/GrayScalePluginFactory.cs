using ImageProcessingFramework.Models;
using ImageProcessingFramework.Plugins;

namespace ImageProcessingFramework.Factories;

public class GrayScalePluginFactory : IEffectPluginFactory
{
    public string EffectName => "Grayscale";

    public IEffectPlugin Create(IEnumerable<EffectParameter> parameters)
    {
        return new GrayscalePlugin(parameters);
    }
}

