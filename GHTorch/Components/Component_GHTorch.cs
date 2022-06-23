using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHTorch.Components
{
    public abstract class Component_GHTorch : GH_Component
    {
        internal Component_GHTorch(string name, string nickname, string description,SubCategory subCategory)
            : base(name, nickname, description, "GHTorch", subCategory.ToString())
        {

        }
    }
}
