using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GHTorch.Wrapper.UnsafeNative
{
    internal static unsafe class NativePytorchInfo
    {
        private const string dllName = "GHTorch.Native.dll";

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SetRandomSeed(long seed);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void GetCUDAInfo(ref bool cudaAvailble, ref bool cudnnAvaibll, ref ulong cudaCount);
    }
}
