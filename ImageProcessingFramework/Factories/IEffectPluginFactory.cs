using ImageProcessingFramework.Models;
using ImageProcessingFramework.Plugins;

namespace ImageProcessingFramework.Factories
{
    public interface IEffectPluginFactory
    {
        string EffectName { get; }
        IEffectPlugin Create(IEnumerable<EffectParameter> parameters);
    }
}