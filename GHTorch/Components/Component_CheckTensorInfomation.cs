using System;
using System.Collections.Generic;
using GHTorch.Parameters;
using GHTorch.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GHTorch.Components
{
    public class Component_CheckTensorInfomation : Component_GHTorch
    {
        public override GH_Exposure Exposure => GH_Exposure.tertiary;

        /// <summary>
        /// Initializes a new instance of the Component_CheckTensorInfomation class.
        /// </summary>
        public Component_CheckTensorInfomation()
          : base("Tensor Infomation", "Tensor Info",
              "Check Tensor Infomation", GHTorch.SubCategory.Tensor)
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
            pManager.AddTextParameter("Description", "D", "Desc", GH_ParamAccess.item);
            pManager.AddTextParameter("RequiresGrad", "G", "Requires Grad", GH_ParamAccess.item);
            pManager.AddTextParameter("DataType", "T", "Data Type", GH_ParamAccess.item);
            pManager.AddTextParameter("Device", "D", "Device", GH_ParamAccess.item);
            pManager.AddTextParameter("Layout", "L", "Layout", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_Tensor tensor = null;
            DA.GetData(0, ref tensor);

            DA.SetData(0, tensor.Value.Description);
            DA.SetData(1, tensor.Value.ReuiqresGrad);
            DA.SetData(2, tensor.Value.DataType);
            DA.SetData(3, tensor.Value.Device);
            DA.SetData(4, tensor.Value.Layout);
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
            get { return new Guid("C5412813-D003-4F91-97A2-447389EE5396"); }
        }
    }
}