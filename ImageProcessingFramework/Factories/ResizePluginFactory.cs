using ImageProcessingFramework.Models;
using ImageProcessingFramework.Plugins;

namespace ImageProcessingFramework.Factories
{
    public class ResizePluginFactory : IEffectPluginFactory
    {
        public string EffectName => "Resize";

        public IEffectPlugin Create(IEnumerable<EffectParameter> parameters)
        {
            return new ResizePlugin(parameters);
        }
    }

}
