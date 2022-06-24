using GHTorch.Wrapper;
using Grasshopper.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHTorch.Types
{
    public class GH_Tensor : GH_Goo<Tensor>
    {
        public override bool IsValid => true;

        public override string TypeName => "Tensor";

        public override string TypeDescription => "Pytorch Tensor";

        public GH_Tensor()
        {

        }

        public GH_Tensor(Tensor tensor)
            :base(tensor)
        {

        }

        public override IGH_Goo Duplicate()
        {
            return new GH_Tensor(Value.Duplicate());
        }

        public override string ToString() => Value.ToString();
    }
}
