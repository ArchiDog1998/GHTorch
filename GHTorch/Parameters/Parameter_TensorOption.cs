using System;
using System.Collections.Generic;
using GHTorch.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GHTorch.Parameters
{
    public class Parameter_TensorOption : Parameter_GHTorch<GH_TensorOption>
    {
        /// <summary>
        /// Initializes a new instance of the Parameter_TensorOption class.
        /// </summary>
        public Parameter_TensorOption()
          : base("Tensor Option", "TensorO",
              "Tensor Option")
        {
        }

        public Parameter_TensorOption(string name, string nickname, string descripiton, GH_ParamAccess access)
            : base(name, nickname, descripiton, access)
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
            get { return new Guid("BA17DD59-8697-4D51-8A90-A5774B7940CA"); }
        }
    }
}