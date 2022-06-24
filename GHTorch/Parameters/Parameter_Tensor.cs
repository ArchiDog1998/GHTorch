using System;
using System.Collections.Generic;
using GHTorch.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GHTorch.Parameters
{
    public class Parameter_Tensor : Parameter_GHTorch<GH_Tensor>
    {
        /// <summary>
        /// Initializes a new instance of the Parameter_Tensor class.
        /// </summary>
        public Parameter_Tensor()
          : base("GHTensor", "Tensor",
              "GHTensor")
        {
        }

        public Parameter_Tensor(string name ,string nickname, string descripiton, GH_ParamAccess access)
            :base(name, nickname, descripiton, access)
        {

        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("CD242988-A6F3-4263-B6AE-0A1DC7E6347D"); }
        }
    }
}