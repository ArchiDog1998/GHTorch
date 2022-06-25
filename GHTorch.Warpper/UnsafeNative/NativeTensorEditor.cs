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

        #region Create
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorEmpty(
            [MarshalAs(UnmanagedType.LPArray)] long[] arrayStart, int count,
            int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorValue(
            [MarshalAs(UnmanagedType.LPArray)] long[] arrayStart, int count, string value,
            int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorRandom(
            [MarshalAs(UnmanagedType.LPArray)] long[] arrayStart, int count, bool normal,
            int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorRandomInt(
            [MarshalAs(UnmanagedType.LPArray)] long[] arrayStart, int count, long low, long high,
            int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorSpace(
            string start, string end, long step, bool isLog,
            int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorEye(
            long n, long m,
            int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorPerm(
            long n, 
            int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorArange(
            string start, string end, string step, 
            int dtype, bool iskSparse, bool isCuda, int cudaIndex, bool requiresGrad);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr DuplicateTensor(IntPtr tensor);

        #endregion

        #region Delete
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DeleteTensor(IntPtr tensor);

        #endregion

        #region Check
        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorDescription(IntPtr tensor);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorRequiresGrad(IntPtr tensor, ref IntPtr boolInt);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorDataType(IntPtr tensor, ref IntPtr boolInt);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorDevice(IntPtr tensor, ref IntPtr boolInt);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr TensorLayout(IntPtr tensor, ref IntPtr boolInt);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DeleteString(IntPtr boolInt);
        #endregion

    }
}
