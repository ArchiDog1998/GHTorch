using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
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

        protected static Param_Integer AddEnumParameter<T>
            (GH_Component.GH_InputParamManager pManager, string name, string nickname, string description, GH_ParamAccess access, int @default = 0) where T : Enum
        {
            Param_Integer param = new Param_Integer();
            param.SetPersistentData(@default);

            pManager.AddParameter(param, name, nickname, description, access);

            string[] names = Enum.GetNames(typeof(T));
            int[] values = (int[])Enum.GetValues(typeof(T));

            if(names.Length != values.Length) return param;

            for (int i = 0; i < names.Length; i++)
            {
                param.AddNamedValue(names[i], values[i]);
            }

            return param;
        }
    }
}
