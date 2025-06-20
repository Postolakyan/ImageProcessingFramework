
using ImageProcessingFramework.Factories;

namespace ImageProcessingFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IEffectPluginFactory, ResizePluginFactory>();
            builder.Services.AddSingleton<IEffectPluginFactory, BlurPluginFactory>();
            builder.Services.AddSingleton<IEffectPluginFactory, GrayScalePluginFactory>();

            builder.Services.AddSingleton<IEffectPluginFactoryProvider, EffectPluginFactoryProvider>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
