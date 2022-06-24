using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using GHTorch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHTorch.Parameters
{
    public abstract class Parameter_GHTorch<T> : GH_Param<T> where T : class, IGH_Goo
    {
        protected Parameter_GHTorch(string name, string nickname, string description, GH_ParamAccess access = GH_ParamAccess.item) 
            : base(name, nickname, description, "GHTorch", GHTorch.SubCategory.Params.ToString(), access)
        {
        }
    }
}
