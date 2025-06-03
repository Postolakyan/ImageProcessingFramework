using ImageProcessingFramework.Models;
using ImageProcessingFramework.Plugins;

namespace ImageProcessingFramework.Factories
{
    public class BlurPluginFactory : IEffectPluginFactory
    {
        public string EffectName => "Blur";

        public IEffectPlugin Create(IEnumerable<EffectParameter> parameters)
        {
            return new BlurPlugin(parameters);
        }
    }

}
