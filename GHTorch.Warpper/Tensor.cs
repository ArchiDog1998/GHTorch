using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GHTorch.Wrapper.UnsafeNative;

namespace GHTorch.Wrapper
{
    public unsafe class Tensor 
    {
        private IntPtr _handle;

        public string Description => IntPtrToString(NativeTensorEditor.TensorDescription(_handle));

        private IntPtr _requiresGradInt = IntPtr.Zero;
        public string ReuiqresGrad
        {
            get
            {
                if(_requiresGradInt != IntPtr.Zero) NativeTensorEditor.DeleteString(_requiresGradInt);
                return IntPtrToString(NativeTensorEditor.TensorRequiresGrad(_handle, ref _requiresGradInt));
            }
        }

        private IntPtr _dataTypeInt = IntPtr.Zero;
        public string DataType
        {
            get
            {
                if (_dataTypeInt != IntPtr.Zero) NativeTensorEditor.DeleteString(_dataTypeInt);
                return IntPtrToString(NativeTensorEditor.TensorDataType(_handle, ref _dataTypeInt));
            }
        }

        private IntPtr _deviceInt = IntPtr.Zero;
        public string Device
        {
            get
            {
                if (_deviceInt != IntPtr.Zero) NativeTensorEditor.DeleteString(_deviceInt);
                return IntPtrToString(NativeTensorEditor.TensorDevice(_handle, ref _deviceInt));
            }
        }

        private IntPtr _layoutInt = IntPtr.Zero;
        public string Layout
        {
            get
            {
                if (_layoutInt != IntPtr.Zero) NativeTensorEditor.DeleteString(_layoutInt);
                return IntPtrToString(NativeTensorEditor.TensorLayout(_handle, ref _layoutInt));
            }
        }


        public Tensor(IntPtr handle)
        {
            _handle = handle;
        }

        ~Tensor()
        {
            NativeTensorEditor.DeleteTensor(_handle);
        }

        public override string ToString()
        {
            string str = Description.Split('\n').LastOrDefault();
            return  str.Substring(2, str.Length - 4);
        }

        public Tensor Duplicate()=> new Tensor(NativeTensorEditor.DuplicateTensor(_handle));
        
        private static string IntPtrToString(IntPtr strPtr) => Marshal.PtrToStringAnsi(strPtr);

        public static Tensor CreateTensorEmpty(TensorOption option, params long[] arrays)
        {
            return new Tensor(NativeTensorEditor.TensorEmpty(arrays, arrays.Length,
                (int)option.DataT, option.IsSparse, option.IsCUDA, option.CUDAIndex, option.RequiresGrad));
        }

        public static Tensor CreateTensorValue(TensorOption option, string value, params long[] arrays)
        {
            return new Tensor(NativeTensorEditor.TensorValue(arrays, arrays.Length, value,
                (int)option.DataT, option.IsSparse, option.IsCUDA, option.CUDAIndex, option.RequiresGrad));
        }

        public static Tensor CreateTensorRandom(TensorOption option, bool normal, params long[] arrays)
        {
            return new Tensor(NativeTensorEditor.TensorRandom(arrays, arrays.Length, normal,
                (int)option.DataT, option.IsSparse, option.IsCUDA, option.CUDAIndex, option.RequiresGrad));
        }

        public static Tensor CreateTensorRandomInt(TensorOption option, long low, long high, params long[] arrays)
        {
            return new Tensor(NativeTensorEditor.TensorRandomInt(arrays, arrays.Length, low, high,
                (int)option.DataT, option.IsSparse, option.IsCUDA, option.CUDAIndex, option.RequiresGrad));
        }

        public static Tensor CreateTensorSpaces(TensorOption option, string start, string end, long step, bool isLog)
        {
            return new Tensor(NativeTensorEditor.TensorSpace(start, end, step, isLog,
                (int)option.DataT, option.IsSparse, option.IsCUDA, option.CUDAIndex, option.RequiresGrad));
        }

        public static Tensor CreateTensorArange(TensorOption option, string start, string end, string step)
        {
            return new Tensor(NativeTensorEditor.TensorArange(start, end, step,
                (int)option.DataT, option.IsSparse, option.IsCUDA, option.CUDAIndex, option.RequiresGrad));
        }

        public static Tensor CreateTensorEye(TensorOption option, long n, long m)
        {
            return new Tensor(NativeTensorEditor.TensorEye(n, m,
                (int)option.DataT, option.IsSparse, option.IsCUDA, option.CUDAIndex, option.RequiresGrad));
        }

        public static Tensor CreateTensorPerm(TensorOption option, long n)
        {
            return new Tensor(NativeTensorEditor.TensorPerm(n,
                (int)option.DataT, option.IsSparse, option.IsCUDA, option.CUDAIndex, option.RequiresGrad));
        }
    }
}
