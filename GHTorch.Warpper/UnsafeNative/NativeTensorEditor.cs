using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GHTorch.Wrapper.UnsafeNative
{
    internal unsafe static class NativeTensorEditor
    {
        private const string dllName = "GHTorch.Native.dll";

        #region Create Tensor
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorRand(
            [MarshalAs(UnmanagedType.LPArray)] long[] arrayStart, int count, bool requiesGrad);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorZeros(
            [MarshalAs(UnmanagedType.LPArray)] long[] arrayStart, int count, bool requiesGrad);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorOnes(
            [MarshalAs(UnmanagedType.LPArray)] long[] arrayStart, int count, bool requiesGrad);
        #endregion

        #region Tensor String
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorToString(IntPtr tensor);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorDescription(IntPtr tensor);
        #endregion

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DeleteTensor(IntPtr tensor);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DuplicateTensor(IntPtr tensor);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr ToCudaTensor(IntPtr tensor);
    }
}
