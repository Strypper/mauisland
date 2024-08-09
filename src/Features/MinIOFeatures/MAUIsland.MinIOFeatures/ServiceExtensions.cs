using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Minio;

namespace MAUIsland.MinIOFeatures;

public static class ServiceExtensions
{
    public static void AddMinIOFeatures(this IServiceCollection services) {
        var settings = new FeatureSettings {
            Endpoint = "minio-api-bit.28.sohan.cloud",
            AccessKey = "petaverse",
            SecretKey = "jyGRA9pgYHQT7UUj7ho3wp6d5odMu4Fy",
            BucketName = "petaverse",
        }
            services.AddSingleton<FeatureSettings>(settings);

        var minio = new MinioClient()
            .WithEndpoint(settings.Endpoint)
            .WithCredentials(settings.AccessKey, settings.SecretKey)
            .WithSSL(true)
            .Build();


        // Add Minio using the custom endpoint and configure additional settings for default MinioClient initialization
        services.AddSingleton<IMinioClient>(minio);
    }
}
