using System;
using System.Collections.Generic;
using GHTorch.Parameters;
using GHTorch.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GHTorch.Components
{
    public class Component_TensorCUDA : Component_GHTorch
    {
        /// <summary>
        /// Initializes a new instance of the Component_TensorCUDA class.
        /// </summary>
        public Component_TensorCUDA()
          : base("TensorCUDA", "CUDA",
              "Conver a tensor into CUDA.", GHTorch.SubCategory.Tensor)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddParameter(new Parameter_Tensor("Tensor", "T", "Tensor to create", GH_ParamAccess.item));
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Parameter_Tensor("Tensor", "T", "Tensor to create", GH_ParamAccess.item));
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_Tensor tensor = null;

            DA.GetData(0, ref tensor);

            DA.SetData(0, new GH_Tensor(tensor.Value.CUDA()));
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
            get { return new Guid("134A31D1-9519-4077-A54A-FC6995D70A14"); }
        }
    }
}