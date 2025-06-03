namespace ImageProcessingFramework.Models;

public class EffectParameter
{
    public string Name { get; set; }
    public int Value { get; set; }

    public EffectParameter(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Name} = {Value}";
    }
}
