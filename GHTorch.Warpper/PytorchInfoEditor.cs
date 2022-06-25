using GHTorch.Wrapper.UnsafeNative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHTorch.Wrapper
{
    public static class PytorchInfoEditor
    {
        public static void SetRandomSeed(long seed)
        {
            NativePytorchInfo.SetRandomSeed(seed);
        }

        public static void GetCUDAInfo(ref bool cudaAvailble, ref bool cudnnAvaibll, ref ulong cudaCount)
        {
            NativePytorchInfo.GetCUDAInfo(ref cudaAvailble, ref cudnnAvaibll, ref cudaCount);
        }
    }
}
