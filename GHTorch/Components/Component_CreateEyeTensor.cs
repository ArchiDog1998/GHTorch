using System;
using System.Collections.Generic;
using GHTorch.Parameters;
using GHTorch.Types;
using GHTorch.Wrapper;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GHTorch.Components
{
    public class Component_CreateEyeTensor : Component_GHTorch
    {
        public override GH_Exposure Exposure => GH_Exposure.primary;

        /// <summary>
        /// Initializes a new instance of the Component_CreateEyeTensor class.
        /// </summary>
        public Component_CreateEyeTensor()
          : base("Create Eye Tensor", "CEyeTensor",
              "Create Eye Tensor", GHTorch.SubCategory.Tensor)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("N", "N", "N", GH_ParamAccess.item, "6");
            pManager[pManager.AddTextParameter("M", "M", "M", GH_ParamAccess.item)].Optional = true;
            pManager[pManager.AddParameter(new Parameter_TensorOption("Option", "O", "Option", GH_ParamAccess.item))].Optional = true;

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
            string n, m;
            n = m = string.Empty;
            GH_TensorOption option = new GH_TensorOption(new TensorOption(TensorOption.DataType.Float32, false, true, 0, false));


            DA.GetData(0, ref n);
            if(!DA.GetData(1, ref m))
            {
                m = n;
            }
            DA.GetData(2, ref option);

            DA.SetData(0, new GH_Tensor(Tensor.CreateTensorEye(option.Value, long.Parse(n), long.Parse(m))));

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
            get { return new Guid("287760E5-8890-4075-82B9-61D07DCA8B79"); }
        }
    }
}