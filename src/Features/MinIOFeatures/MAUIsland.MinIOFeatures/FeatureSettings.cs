using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIsland.MinIOFeatures;

public class FeatureSettings
{
    public string Endpoint { get; set; } = "minio-api-bit.28.sohan.cloud";
    public string AccessKey { get; set; } = "petaverse";
    public string SecretKey { get; set; } = "jyGRA9pgYHQT7UUj7ho3wp6d5odMu4Fy";
    public string BucketName { get; set; } = "petaverse";

    public FeatureSettings()
    {
        
    }
}
