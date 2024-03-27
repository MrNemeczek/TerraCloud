using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTOs.Device.Responses;

namespace TerraCloud.Application.Interfaces.Device
{
    public interface IGetDevices
    {
        Task<IEnumerable<DeviceResponse>> Execute();
    }
}
