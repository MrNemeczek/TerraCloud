using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTOs.Device.Requests;

namespace TerraCloud.Application.Interfaces.Device
{
    public interface IAddUserDevice
    {
        Task Execute(AddUserDeviceRequest request, Guid userId);
    }
}
