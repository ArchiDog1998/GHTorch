using GHTorch.Wrapper;
using Grasshopper.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHTorch.Types
{
    public class GH_TensorOption : GH_Goo<TensorOption>
    {
        public override bool IsValid => true;

        public override string TypeName => "Tensor Option";

        public override string TypeDescription => "Tensor Option";

        public GH_TensorOption()
        {

        }

        public GH_TensorOption(TensorOption tensorOption)
            : base(tensorOption)
        {

        }

        public override IGH_Goo Duplicate() => new GH_TensorOption(Value.Duplicate());

        public override string ToString() => Value.ToString();
    }
}
