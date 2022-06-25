using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHTorch.Wrapper
{
    public struct TensorOption
    {
        public enum DataType
        {
            UInt8,
            Int8,
            Int16,
            Int32,
            Int64,
            Float16,
            Float32,
            Float64,
        }

        public DataType DataT { get; }

        public bool IsSparse { get; }

        public bool IsCUDA { get; }

        public int CUDAIndex { get; }

        public bool RequiresGrad { get; }

        public TensorOption(DataType dType, bool isSparse, bool isCUDA, int CUDAIndex, bool requiresGrad)
        {
            DataT = dType;
            IsSparse = isSparse;
            IsCUDA = isCUDA;
            this.CUDAIndex = CUDAIndex;
            RequiresGrad = requiresGrad;
        }

        public TensorOption Duplicate()
        {
            return new TensorOption(DataT, IsSparse, IsCUDA, CUDAIndex, RequiresGrad);
        }

        public override string ToString()
        {
            return nameof(TensorOption);
        }
    }
}
