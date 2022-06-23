using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHTorch
{
    public class GHTorchPriority : GH_AssemblyPriority
    {
        public override GH_LoadingInstruction PriorityLoad()
        {
            //TorchInit.Init();
            return GH_LoadingInstruction.Proceed;
        }
    }
}
