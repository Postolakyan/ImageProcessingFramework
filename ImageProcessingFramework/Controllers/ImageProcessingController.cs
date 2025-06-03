using ImageProcessingFramework.DTO;
using ImageProcessingFramework.Factories;
using ImageProcessingFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ImageProcessingFramework.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageProcessingController : ControllerBase
{
    private readonly IEffectPluginFactoryProvider _pluginFactoryProvider;

    public ImageProcessingController(IEffectPluginFactoryProvider pluginFactoryProvider)
    {
        _pluginFactoryProvider = pluginFactoryProvider;
    }

    [HttpPost("process")]
    public IActionResult ProcessImages([FromBody] List<ImageRequest> images)
    {
        try
        {
            foreach (var imageRequest in images)
            {
                var image = new ImageData(imageRequest.Name);

                foreach (var effect in imageRequest.Effects)
                {
                    var plugin = _pluginFactoryProvider.CreatePlugin(effect.EffectName, effect.Parameters);

                    plugin.Validate();
                    plugin.Apply(image);
                }
            }

            return Ok("All images processed successfully.");
        }
        catch (ValidationException vex)
        {
            return BadRequest($"Validation error: {vex.Message}");
        }
        catch (System.Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }

}

