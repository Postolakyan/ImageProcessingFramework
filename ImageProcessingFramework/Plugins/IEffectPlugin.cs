using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.Plugins;

public interface IEffectPlugin
{
    string Name { get; }
    IEnumerable<EffectParameter> Parameters { get; }
    void Apply(ImageData image);
    void Validate();
}