using ImageProcessingFramework.Models;
using System.ComponentModel.DataAnnotations;

namespace ImageProcessingFramework.Plugins;
public class ResizePlugin : IEffectPlugin
{
    public string Name => "Resize";
    public IEnumerable<EffectParameter> Parameters { get; }

    private readonly int _width;

    public ResizePlugin(IEnumerable<EffectParameter> parameters)
    {
        Parameters = parameters.ToList();
        _width = Parameters
            .FirstOrDefault(p => p.Name.ToLower() == "width")?.Value as int?
            ?? throw new ArgumentException("Missing or invalid 'width' parameter.");
    }

    public void Validate()
    {
        if (_width <= 0)
            throw new ValidationException("'width' must be a positive integer.");
    }

    public void Apply(ImageData image)
    {
        Validate();
        image.Metadata["ResizedTo"] = $"{_width}px";
    }
}

