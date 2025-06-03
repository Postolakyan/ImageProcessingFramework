
using ImageProcessingFramework.Models;
using ImageProcessingFramework.Plugins;

namespace ImageProcessingFramework.Factories
{
    public interface IEffectPluginFactoryProvider
    {
        IEffectPlugin CreatePlugin(string effectName, IEnumerable<EffectParameter> parameters);
    }
}