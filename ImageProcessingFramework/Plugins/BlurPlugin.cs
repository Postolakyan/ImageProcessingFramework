using ImageProcessingFramework.Models;
using System.ComponentModel.DataAnnotations;

namespace ImageProcessingFramework.Plugins;

public class BlurPlugin : IEffectPlugin
{
    public string Name => "Blur";
    public IEnumerable<EffectParameter> Parameters { get; }

    private readonly int _radius;

    public BlurPlugin(IEnumerable<EffectParameter> parameters)
    {
        Parameters = parameters.ToList();
        _radius = Parameters
            .FirstOrDefault(p => p.Name.ToLower() == "radius")?.Value as int?
            ?? throw new ArgumentException("Missing or invalid 'radius' parameter.");
    }

    public void Validate()
    {
        if (_radius < 0)
            throw new ValidationException("'radius' must be zero or a positive integer.");
    }

    public void Apply(ImageData image)
    {
        Validate();
        image.Metadata["BlurRadius"] = $"{_radius}px";
    }
}

