using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIsland.MinIOFeatures;

public interface IMinIOServices
{
    Task PostAsync();
    Task CheckStatAsync();
    Task GetFileAsync();
    Task GetStreamAsync();
}
