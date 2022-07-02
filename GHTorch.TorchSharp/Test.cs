using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorchSharp;

namespace GHTorch.TorchSharp
{
    public class Test
    {
        public static string TestFunc()
        {
            torch.InitializeDeviceType(DeviceType.CUDA);
            return  torch.rand(new long[] { 2, 3 }).ToString();
        }
    }
}
