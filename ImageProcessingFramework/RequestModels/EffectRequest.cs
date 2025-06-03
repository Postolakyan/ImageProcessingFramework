using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.DTO;

public class EffectRequest
{
    public string EffectName { get; set; }
    public List<EffectParameter> Parameters { get; set; }
}
