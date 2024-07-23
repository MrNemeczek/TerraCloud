using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraCloud.Application.DTOs.Device.Requests
{
    public class AddUserDeviceRequest
    {
        public string Name { get; set; }
        public string UniqueCode { get; set; }
    }
}
