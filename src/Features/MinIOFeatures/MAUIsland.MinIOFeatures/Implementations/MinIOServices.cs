using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIsland.MinIOFeatures;

public class MinIOServices : IMinIOServices
{
    private readonly FeatureSettings _settings;
    public MinIOServices(FeatureSettings settings)
    {
        this._settings = settings;
    }

    public Task CheckStatAsync() {
        throw new NotImplementedException();
    }

    public Task GetFileAsync() {
        throw new NotImplementedException();
    }

    public Task GetStreamAsync() {
        throw new NotImplementedException();
    }

    public Task PostAsync() {
        throw new NotImplementedException();
    }
}
