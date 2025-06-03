using ImageProcessingFramework.Plugins;

namespace ImageProcessingFramework.Models;

public class ImageData
{
    public string Name { get; set; }
    public byte[] Content { get; set; }
    public Dictionary<string, string> Metadata { get; private set; }
    public List<IEffectPlugin> Effects { get; private set; }

    public ImageData(string name)
    {
        Name = name;
        Content = new byte[0];
        Metadata = new Dictionary<string, string>();
        Effects = new List<IEffectPlugin>();
    }
    public void ApplyEffects()
    {
        foreach (var effect in Effects)
        {
            effect.Apply(this);
        }
    }
}
