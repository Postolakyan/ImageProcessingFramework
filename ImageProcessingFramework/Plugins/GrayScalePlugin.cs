using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.Plugins;

public class GrayscalePlugin : IEffectPlugin
{
    public string Name => "Grayscale";
    public IEnumerable<EffectParameter> Parameters { get; }

    public GrayscalePlugin(IEnumerable<EffectParameter> parameters)
    {
        Parameters = parameters.ToList();
        if (Parameters.Any())
            throw new ArgumentException("Grayscale effect does not accept parameters.");
    }

    public void Validate()
    {
        // No parameters to validate
    }

    public void Apply(ImageData image)
    {
        Validate();
        image.Metadata["ConvertedTo"] = "Grayscale";
    }
}


