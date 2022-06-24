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
        
        public Tensor CUDA() => new Tensor(NativeTensorEditor.ToCudaTensor(_handle));

        private static string IntPtrToString(IntPtr strPtr) => Marshal.PtrToStringAnsi(strPtr);

        public static Tensor CreateTensor(CreateTensorFunction func, bool requiresGrad, params long[] arrays)
        {
            switch (func)
            {
                case CreateTensorFunction.Random:
                    return new Tensor(NativeTensorEditor.TensorRand(arrays, arrays.Length, requiresGrad));
                case CreateTensorFunction.Ones:
                    return new Tensor(NativeTensorEditor.TensorOnes(arrays, arrays.Length, requiresGrad));
                case CreateTensorFunction.Zeros:
                    return new Tensor(NativeTensorEditor.TensorZeros(arrays, arrays.Length, requiresGrad));
            }
            return null;
        }
    }
}
